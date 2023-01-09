#pragma once

#include <string>
#include <cstdlib>
#include <fstream>
#include <iostream>

#include "Dependencies\glew.h"
#include "Dependencies\wglew.h"
#include "Dependencies\glm/glm.hpp"
#include "Dependencies\glm/gtc/matrix_transform.hpp"
#include "Dependencies\glm/gtx/euler_angles.hpp"

class Renderer
{
public:
	Renderer(int windowSizeX, int windowSizeY);
	~Renderer();

	GLuint CreatePngTexture(char * filePath);
	GLuint CreateBmpTexture(char * filePath);
	   
	void Test();
	void Lecture2();
	void Lecture3();
	void Lecture3_Particle();
	void Lecture4_FSSandbox();
	void Lecture4_Raindrop();
	void Lecture4_RadarCircle();
	void Lecture5_LineSegment();
	void Lecture5_FullRect();
	void Lecture6_Texture();

private:
	void Initialize(int windowSizeX, int windowSizeY);
	bool ReadFile(char* filename, std::string *target);
	void AddShader(GLuint ShaderProgram, const char* pShaderText, GLenum ShaderType);
	GLuint CompileShaders(char* filenameVS, char* filenameFS);
	void CreateVertexBufferObjects(); 
	unsigned char * Renderer::loadBMPRaw(const char * imagepath, unsigned int& outWidth, unsigned int& outHeight);
	void CreateParitcle(int count);
	
	void CreateLine(int SegCount);

	void CreateTextures();

	bool m_Initialized = false;
	
	unsigned int m_WindowSizeX = 0;
	unsigned int m_WindowSizeY = 0;

	//camera position
	glm::vec3 m_v3Camera_Position;
	//camera lookat position
	glm::vec3 m_v3Camera_Lookat;
	//camera up vector
	glm::vec3 m_v3Camera_Up;

	glm::mat4 m_m4OrthoProj;
	glm::mat4 m_m4PersProj;
	glm::mat4 m_m4Model;
	glm::mat4 m_m4View;
	glm::mat4 m_m4ProjView;

	GLuint m_VBORect = 0;
	GLuint m_SolidRectShader = 0;

	GLuint m_VBOLecture2 = 0;
	GLuint m_VBOLecture3 = 0;
	
	GLuint m_Lecture3Shader = 0;

	GLuint m_VBOSingleParticleQuad = 0;
	GLuint m_Lecture3ParticleShader = 0;

	GLuint m_VBOManyParticle = 0;
	GLuint m_VBOManyParticleVertexCount = 0;

	GLuint m_VBOSandbox = 0;
	GLuint m_FSSandboxShader = 0;

	GLuint m_VBOPack0_Pos = 0;
	GLuint m_VBOPack0_Color= 0;
	GLuint m_VBOPack1 = 0;

	GLuint m_VBOLineSegment = 0;
	GLuint m_VBOLineSegmentCount = 0;

	GLuint m_LineSegmentShader = 0;

	GLuint m_VBOFullRect = 0;
	GLuint m_FullRectShader = 0;

	GLuint m_TexChecker = 0;
	GLuint m_TextureSandboxShader = 0;
	GLuint m_VBOTexSandbox = 0;

	GLuint m_TexRGB = 0;
};

