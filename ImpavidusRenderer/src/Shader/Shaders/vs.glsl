#version 400 core

in vec2 position;
uniform vec2 u_color;
out vec2 color;

void main(void)
{
  color = vec2(u_color.x * sin(position.x), u_color.y * sin(position.y));
	gl_Position = vec4(position,0.0, 1.0);
}