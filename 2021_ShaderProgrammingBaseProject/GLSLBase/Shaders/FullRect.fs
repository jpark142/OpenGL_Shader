#version 450

layout(location=0) out vec4 FragColor;

in vec2 v_TexCoord;

uniform float u_Time;

const float PI = 3.141592;

void main()
{
    float sinValue = 0.5 * sin(2.0 * v_TexCoord.x * 2.0 * PI + u_Time);
    if(v_TexCoord.y * 2.0 - 1.0 < sinValue && v_TexCoord.y * 2.0 - 1.0 > sinValue - 0.008)
    {
        FragColor = vec4(1);
    }
    else
    {
        FragColor = vec4(0);
    }

}
