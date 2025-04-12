using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tao.OpenGl;
using Tao.FreeGlut;
namespace ProjetoPonto
{
    class Program
    {
        static void inicializa()
        {
            Gl.glMatrixMode(Gl.GL_MODELVIEW);
            Gl.glLoadIdentity();
            Glu.gluOrtho2D(0, 100, 0, 100);
            Gl.glClearColor(1.0f, 1.0f, 1.0f, 0.0f);

        }
        static void Paisagem()
        {
            Gl.glClear(Gl.GL_COLOR_BUFFER_BIT);

            //Grama
            Gl.glColor3f(0.0f, 0.7f, 0.0f);
            Gl.glBegin(Gl.GL_QUADS);
            Gl.glVertex2i(0, 40);
            Gl.glVertex2i(100, 40);
            Gl.glVertex2i(100, 0);
            Gl.glVertex2i(0, 0);
            Gl.glEnd();

            //Céu
            Gl.glColor3f(0.2f, 0.6f, 1.0f);
            Gl.glBegin(Gl.GL_QUADS);
            Gl.glVertex2i(0, 40);
            Gl.glVertex2i(100, 40);
            Gl.glColor3f(0.4f, 0.7f, 1.0f);
            Gl.glVertex2i(100, 100);
            Gl.glVertex2i(0, 100);
            Gl.glEnd();


        }
        static void Main()
        {
            Glut.glutInit();
            Glut.glutInitDisplayMode(Glut.GLUT_SINGLE | Glut.GLUT_RGB);
            Glut.glutInitWindowSize(600, 400);
            Glut.glutCreateWindow("Fazenda");

            inicializa();
            Glut.glutDisplayFunc(Paisagem);
            Glut.glutMainLoop();
        }
    }
}