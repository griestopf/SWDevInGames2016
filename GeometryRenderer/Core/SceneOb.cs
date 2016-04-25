using System.Collections.Generic;
using Fusee.Engine.Common;
using Fusee.Engine.Core;
using Fusee.Math.Core;

namespace Fusee.Tutorial.Core
{

    public class SceneItem
    {
        public virtual void Render(RenderContext rc)
        {
        }
    }

    public class Material : SceneItem
    {
        public float3 Albedo;
        public IShaderParam AlbedoParam;

        public override void Render(RenderContext rc)
        {
            rc.SetShaderParam(AlbedoParam, Albedo);
        }
    }

    public class Transform : SceneItem
    {
        public float3 Pos = float3.Zero;
        public float3 Rot = float3.Zero;
        public float3 Scale = float3.One;

        public override void Render(RenderContext rc)
        {
            rc.ModelView = rc.ModelView*
                           float4x4.CreateTranslation(Pos)
                           *float4x4.CreateRotationY(Rot.y)
                           *float4x4.CreateRotationX(Rot.x)
                           *float4x4.CreateRotationZ(Rot.z)
                           *float4x4.CreateScale(Scale);
        }
    }

    public class Group : SceneItem
    {
        public List<SceneItem> Children;

        public override void Render(RenderContext rc)
        {
            float4x4 mvOld = rc.ModelView;
            foreach (var child in Children)
                child.Render(rc);
            rc.ModelView = mvOld;
        }
    }

    public class Geometry : SceneItem
    {
        public Mesh Mesh;

        public override void Render(RenderContext rc)
        {
            rc.Render(Mesh);
        }
    }


    public class SceneOb
    {
        public Mesh Mesh;
        public float3 Albedo = new float3(0.8f, 0.8f, 0.8f);
        public float3 Pos = float3.Zero;
        public float3 Rot = float3.Zero;
        public float3 Pivot = float3.Zero;
        public float3 Scale = float3.One;
        public float3 ModelScale = float3.One;
        public List<SceneOb> Children;
    }


}
