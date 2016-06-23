#ifdef GL_ES
    precision highp float;
#endif

uniform vec4 linecolor;
  varying vec3 normal;

void main()
{
    float daZ = gl_FragCoord.z * 30.0 - 29.0; // /2.0
    gl_FragColor = vec4(daZ, daZ, daZ, 1); // linecolor;
}    