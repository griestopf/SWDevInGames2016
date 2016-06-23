  attribute vec3 fuVertex;
  attribute vec3 fuNormal;

  varying vec3 normal;

  uniform mat4 FUSEE_MVP;
  uniform mat4 FUSEE_ITMV;

  uniform vec2 linewidth;

  void main()
  {
      normal = mat3(FUSEE_ITMV[0].xyz, FUSEE_ITMV[1].xyz, FUSEE_ITMV[2].xyz) * fuNormal;
      normal = normalize(normal);
      gl_Position = (FUSEE_MVP * vec4(fuVertex, 1.0) ) + vec4(linewidth * normal.xy, 0, 0); // + vec4(0, 0, 0.06, 0);
  }    
