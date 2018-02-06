#version 400 core


out vec4 out_Color;
uniform vec2 u_color;

void main(void)
{
	out_Color = vec4(1.0,u_color.y,0.0,1.0);
}