#version 450

layout(location=0) out vec4 FragColor;

in vec4 v_Color;
const float PI = 3.141592;

uniform vec3 u_Points[10];
uniform float u_Time;

vec4 CrossPattern()
{
	vec4 returnValue = vec4(1, 1, 1, 1);
	float XAxis = sin(10 * (v_Color.x * 2 * PI) + 0.5 * PI);
	float YAxis = sin(10 * (v_Color.y * 2 * PI) + 0.5 * PI);
	float resultColor = max(XAxis, YAxis);
	returnValue = vec4(resultColor);
	
	return returnValue;
}

vec4 DrawCircleLine()
{
	float dis = distance(v_Color.xy, vec2(0.5, 0.5));
	vec4 newColor = vec4(0,0,0,0);

	if(dis < 0.5 && dis > 0.49)
		newColor = vec4(1, 1, 1, 1);
	else
		newColor = vec4(0, 0, 0, 0);

	return newColor;
}

vec4 DrawMultipleCircles()
{
	float dis = distance(v_Color.xy, vec2(0.5, 0.5)); //0 ~ 0.5
	float temp = sin(10 * (dis * 4 * PI));

	return vec4(temp);
}

vec4 DrawCircles()
{
	vec4 returnColor = vec4(0);
	for(int i = 0; i < 10; ++i){
		float dis = distance(u_Points[i].xy, v_Color.xy);
		float temp = sin(10 * (dis * 4 * PI - u_Time* 5 ));
		
		if(dis < u_Time)
			returnColor += vec4(temp);
	}
	
	return returnColor;
	
}

vec4 RadarCircle()
{
	float d = distance(vec2(0.5, -0.1), v_Color.xy);
	float sinValue = sin(2 * d * 2 * PI - u_Time*50);
	sinValue = pow(sinValue, 16);
	vec4 returnColor = vec4(sinValue);

	for(int i = 0; i < 10; ++i){
		float dis = distance(u_Points[i].xy, v_Color.xy);
		float temp = sin((dis * 4 * PI));
		temp = clamp(temp, 0, 1);
		if(dis < 0.2)
			returnColor += 0.2 * vec4(temp);
	}

	
	return returnColor;
}

void main()
{
	FragColor = RadarCircle();
}
