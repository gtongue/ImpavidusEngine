#version 400 core

attribute vec2 position;
attribute vec2 position1;

void main(void)
{
	gl_Position = vec4(position,position1.x, 1.0);
}