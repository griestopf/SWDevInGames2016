#ifdef GL_ES
    precision highp float;
#endif
varying vec3 viewpos;
varying vec3 normal;
uniform vec3 albedo;
uniform float shininess;
uniform float specfactor;
uniform vec3 speccolor;
uniform vec3 ambientcolor;

void main()
{
	vec3 nnormal = normalize(normal);
	
	// Diffuse
	vec3 lightdir = vec3(0, 0, -1);
    float intensityDiff = dot(nnormal, lightdir);

	// Specular
    float intensitySpec = 0.0;
	if (intensityDiff > 0.0)
	{
		vec3 viewdir = -viewpos;
		vec3 h = normalize(viewdir+lightdir);
		intensitySpec = specfactor * pow(max(0.0, dot(h, nnormal)), shininess);
	}
	float daZ = gl_FragCoord.z * 30.0 - 29.0; 
    // gl_FragColor = vec4(daZ, daZ, daZ, 1); // linecolor;
    gl_FragColor = vec4(ambientcolor + intensityDiff * albedo + intensitySpec * speccolor, 1);
}
