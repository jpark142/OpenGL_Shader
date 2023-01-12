#version 450

layout(location=0) out vec4 FragColor;

in vec4 v_Color;
in vec4 v_ColorOverride;
const float PI = 3.141592;

uniform vec3 u_Points[10];
uniform float u_Time;


vec4 RadarCircle()
{
	float d = distance(vec2(0.5, -0.1), v_Color.xy);
	float sinValue = sin(d * 2 * PI - u_Time*50);
	sinValue = clamp(pow(sinValue, 4), 0, 1);
	vec4 returnColor = vec4(0.5 * sinValue);

	for(int i = 0; i < 10; ++i){
		float dis = distance(u_Points[i].xy, v_Color.xy);
		if(dis < 0.1)
			returnColor += 
			vec4(0, 20 *sinValue * (0.1 - dis), 0, 0);
	}

	
	return returnColor;
}

void main()
{
	FragColor = RadarCircle() * v_ColorOverride;
}
