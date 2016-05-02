using System;
using System.Collections.Generic;
using Fusee.Engine.Common;
using Fusee.Engine.Core;
using Fusee.Math.Core;
using Fusee.Xene;

namespace Fusee.Tutorial.Core
{

    public class SceneItem
    {
        public virtual void Accept(Visitor visitor)
        {
        }
    }

    public class Material : SceneItem
    {
        public float3 Albedo;
        public IShaderParam AlbedoParam;

        public override void Accept(Visitor visitor)
        {
            visitor.Visit(this);
        }
    }

    public class Transform : SceneItem
    {
        public float3 Pos = float3.Zero;
        public float3 Rot = float3.Zero;
        public float3 Scale = float3.One;

        public override void Accept(Visitor visitor)
        {
            visitor.Visit(this);
        }
    }

    public class Group : SceneItem
    {
        public List<SceneItem> Children;

        public override void Accept(Visitor visitor)
        {
            visitor.Visit(this);
        }
    }

    public class Geometry : SceneItem
    {
        public Mesh Mesh;

        public override void Accept(Visitor visitor)
        {
            visitor.Visit(this);
        }
    }


    public abstract class Visitor 
    {
        public void TraverseChildren(Group group)
        {
            foreach (var child in group.Children)
                child.Accept(this);
        }

        public virtual void Visit(Group group)
        {

        }

        public virtual void Visit(Material mat)
        {

        }

        public virtual void Visit(Transform xform)
        {

        }

        public virtual void Visit(Geometry geometry)
        {

        }

    }

    public class RenderVisitor : Visitor
    {
        public RenderContext rc;
        public override void Visit(Group group)
        {
            float4x4 mvOld = rc.ModelView;
            TraverseChildren(group);
            rc.ModelView = mvOld;
        }

        public override void Visit(Material mat)
        {
            rc.SetShaderParam(mat.AlbedoParam, mat.Albedo);
        }

        public override void Visit(Transform xform)
        {
            rc.ModelView = rc.ModelView *
                                      float4x4.CreateTranslation(xform.Pos)
                                      * float4x4.CreateRotationY(xform.Rot.y)
                                      * float4x4.CreateRotationX(xform.Rot.x)
                                      * float4x4.CreateRotationZ(xform.Rot.z)
                                      * float4x4.CreateScale(xform.Scale);
        }

        public override void Visit(Geometry geometry)
        {
            rc.Render(geometry.Mesh);
        }
    }
}
