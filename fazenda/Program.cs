using System;
using Tao.OpenGl;
using Tao.FreeGlut;

namespace ProjetoPonto
{
    class Program
    {
        static float posSolX = 0;
        static float posPortaY = 0;
        static bool teclaEspaco = false;
        static bool ehDia = true;

        static void inicializa()
        {
            Gl.glMatrixMode(Gl.GL_PROJECTION);
            Gl.glLoadIdentity();
            Glu.gluOrtho2D(0, 100, 0, 100);
            Gl.glClearColor(1.0f, 1.0f, 1.0f, 0.0f);
        }

        static void desenharSol()
        {
            Gl.glPushMatrix();
            Gl.glTranslatef(posSolX, 0, 0);

            Gl.glColor3f(1.0f, 1.0f, 0.0f);
            Gl.glBegin(Gl.GL_TRIANGLE_FAN);
            Gl.glVertex2f(0, 90);
            int numLados = 100;
            float raio = 5.0f;
            for (int i = 0; i <= numLados; i++)
            {
                double ang = i * 2.0 * Math.PI / numLados;
                float x = (float)(raio * Math.Cos(ang));
                float y = (float)(raio * Math.Sin(ang));
                Gl.glVertex2f(x, y + 90);
            }
            Gl.glEnd();

            Gl.glPopMatrix();
        }


        static void desenharLua()
        {
            Gl.glPushMatrix();
            Gl.glTranslatef(posSolX, 0, 0);

            Gl.glColor3f(0.9f, 0.9f, 1.0f);
            Gl.glBegin(Gl.GL_TRIANGLE_FAN);
            Gl.glVertex2f(0, 90);
            int numLados = 100;
            float raio = 4.0f;
            for (int i = 0; i <= numLados; i++)
            {
                double ang = i * 2.0 * Math.PI / numLados;
                float x = (float)(raio * Math.Cos(ang));
                float y = (float)(raio * Math.Sin(ang));
                Gl.glVertex2f(x, y + 90);
            }
            Gl.glEnd();

            Gl.glColor3f(0.0f, 0.0f, 0.1f);
            Gl.glBegin(Gl.GL_TRIANGLE_FAN);
            Gl.glVertex2f(1.5f, 90);
            float raioSombra = 4.0f;
            for (int i = 0; i <= numLados; i++)
            {
                double ang = i * 2.0 * Math.PI / numLados;
                float x = (float)(raioSombra * Math.Cos(ang));
                float y = (float)(raioSombra * Math.Sin(ang));
                Gl.glVertex2f(x + 1.5f, y + 90);
            }
            Gl.glEnd();

            Gl.glPopMatrix();
        }


        static void desenharCasa()
        {
            if (ehDia)
                Gl.glColor3f(0.6f, 0.3f, 0.0f);
            else
                Gl.glColor3f(0.4f, 0.15f, 0.0f);


            Gl.glBegin(Gl.GL_QUADS);
            Gl.glVertex2f(30, 40);
            Gl.glVertex2f(50, 40);
            Gl.glVertex2f(50, 60);
            Gl.glVertex2f(30, 60);
            Gl.glEnd();

            if (ehDia)
                Gl.glColor3f(0.8f, 0.0f, 0.0f);
            else
                Gl.glColor3f(0.5f, 0.0f, 0.0f);


            Gl.glBegin(Gl.GL_TRIANGLES);
            Gl.glVertex2f(30, 60);
            Gl.glVertex2f(50, 60);
            Gl.glVertex2f(40, 70);
            Gl.glEnd();


            Gl.glColor3f(0.1f, 0.1f, 0.0f);

            Gl.glBegin(Gl.GL_QUADS);
            Gl.glVertex2f(38, 40);
            Gl.glVertex2f(42, 40);
            Gl.glVertex2f(42, 50);
            Gl.glVertex2f(38, 50);
            Gl.glEnd();

            Porta();



        }

        static void Porta()
        {
            if (ehDia)
                Gl.glColor3f(0.3f, 0.2f, 0.0f);
            else
                Gl.glColor3f(0.15f, 0.1f, 0.0f);

            Gl.glPushMatrix();
            Gl.glTranslatef(38, 40, 0);
            Gl.glRotatef(posPortaY, 0, 1, 0);
            Gl.glTranslatef(-38, -40, 0);

            Gl.glBegin(Gl.GL_QUADS);
            Gl.glVertex2f(38, 40);
            Gl.glVertex2f(42, 40);
            Gl.glVertex2f(42, 50);
            Gl.glVertex2f(38, 50);
            Gl.glEnd();

            Gl.glPopMatrix();
        }

        static void Paisagem()
        {
            // Fundo do céu: muda dependendo se é dia ou noite
            if (ehDia)
            {
                Gl.glClearColor(0.4f, 0.7f, 1.0f, 1.0f);
                Gl.glClear(Gl.GL_COLOR_BUFFER_BIT);
                Gl.glColor3f(0.0f, 0.7f, 0.0f);
            }

            else
            {
                Gl.glClearColor(0.0f, 0.0f, 0.1f, 1.0f);
                Gl.glClear(Gl.GL_COLOR_BUFFER_BIT);
                Gl.glColor3f(0.0f, 0.2f, 0.0f);
            }


            //Gl.glClear(Gl.GL_COLOR_BUFFER_BIT);

            // Grama
            //Gl.glColor3f(0.0f, 0.7f, 0.0f);
            Gl.glBegin(Gl.GL_QUADS);
            Gl.glVertex2i(0, 40);
            Gl.glVertex2i(100, 40);
            Gl.glVertex2i(100, 0);
            Gl.glVertex2i(0, 0);
            Gl.glEnd();

            // Casa
            desenharCasa();

            if (ehDia)
            {
                desenharSol();
            }
            else
            {
                desenharLua();
            }

            Gl.glFlush();
        }

        static void AtualizarCena(int valor)
        {
            posSolX += 0.5f;

            if (posSolX > 100)
            {
                posSolX = 0;
                ehDia = !ehDia;
            }

            Glut.glutPostRedisplay();
            Glut.glutTimerFunc(50, AtualizarCena, 0);
        }

        static void TeclaEspecial(int tecla, int x, int y)
        {
            // Direita
            if (tecla == Glut.GLUT_KEY_RIGHT)
            {
                posSolX += 2f;
                if (posSolX > 100)
                {
                    posSolX = 0;
                    ehDia = !ehDia;
                }
            }

            // Esquerda
            if (tecla == Glut.GLUT_KEY_LEFT)
            {
                posSolX -= 2f;
                if (posSolX < 0)
                {
                    posSolX = 100;
                    ehDia = !ehDia;
                }
            }

            if (tecla == Glut.GLUT_KEY_UP)
            {
                if (posPortaY < 90)
                    posPortaY += 5;
            }

            if (tecla == Glut.GLUT_KEY_DOWN)
            {
                if (posPortaY > 0)
                    posPortaY -= 5;
            }


            Glut.glutPostRedisplay();
        }

        static void Main()
        {
            Glut.glutInit();
            Glut.glutInitDisplayMode(Glut.GLUT_SINGLE | Glut.GLUT_RGB);
            Glut.glutInitWindowSize(600, 400);
            Glut.glutInitWindowPosition(100, 100);
            Glut.glutCreateWindow("Paisagem de Fazenda");

            inicializa();
            Glut.glutDisplayFunc(Paisagem);
            Glut.glutTimerFunc(0, AtualizarCena, 0);
            Glut.glutSpecialFunc(TeclaEspecial);
            Glut.glutMainLoop();
        }
    }
}
