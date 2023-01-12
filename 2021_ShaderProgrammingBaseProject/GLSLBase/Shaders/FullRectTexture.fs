#version 450

layout(location=0) out vec4 FragColor;

in vec2 v_TexCoord;

uniform sampler2D u_TexSampler;

const float PI = 3.141592;

void main()
{
    FragColor = texture(u_TexSampler, v_TexCoord);

}
