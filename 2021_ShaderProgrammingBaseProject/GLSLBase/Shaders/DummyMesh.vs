#version 450

in vec3 a_Position;

uniform float u_Time;

const float PI = 3.141592;

out vec4 v_Color;

void Flag()
{
	vec3 newPos = a_Position;
	float dis = distance(newPos.xy, vec2(-0.5, 0));
	float dis_x = distance(newPos.xy, vec2(-0.5, 0));

	float y_val = dis_x * 0.25 * sin(dis * 2.0 * PI - u_Time);
	float x_val = dis_x * 0.05 * cos(dis * 2.0 * PI - u_Time);
	newPos.y += y_val;
	newPos.x += x_val;
	gl_Position = vec4(newPos, 1);

	v_Color = vec4((sin((a_Position.x + 0.5) * 2.0 * PI - u_Time) + 1.0) / 2.0 + 0.2);
}

void main()
{
	Flag();
}
