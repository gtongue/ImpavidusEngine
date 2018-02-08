#version 400 core


out vec4 out_Color;
in vec2 color;

void main(void)
{
	out_Color = vec4(color,0.0,1.0);
}