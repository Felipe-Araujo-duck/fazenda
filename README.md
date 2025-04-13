# 🌄 Computação Gráfica e RA — Paisagem Interativa com OpenGL

Este projeto foi desenvolvido como trabalho avaliativo da disciplina de **Geometria 2D** no curso de Ciência da Computação.  
Ele utiliza **C# com OpenGL** (através da biblioteca `Tao.OpenGl` e `Tao.FreeGlut`) para renderizar uma **animação gráfica 2D interativa** no console do .NET Framework.

---

## 🧩 Descrição

A aplicação exibe uma paisagem simples e animada com:

- 🌿 Grama
- 🏡 Uma pequena casa
- ☁️ Céu (com mudança dinâmica entre dia e noite)
- ☀️ Sol que se move de forma automática
- 🌙 Lua com efeito de fase (aparece durante a noite)

A cada ciclo completo do sol/lua atravessando a tela, o tempo troca entre **dia** e **noite** automaticamente.  
O usuário também pode **controlar o tempo manualmente** usando as **setas do teclado**.

---

## 🎮 Controles

| Tecla         | Ação                                  |
|---------------|----------------------------------------|
| ⬅️ Esquerda   | Move o sol/lua para a esquerda         |
| ➡️ Direita    | Move o sol/lua para a direita          |

> Ao mover o sol/lua para fora da tela, o ciclo entre dia e noite é alternado.

---

## 💻 Tecnologias Utilizadas

- C# (.NET Framework)
- OpenGL (via Tao Framework)
  - `Tao.OpenGl`
  - `Tao.FreeGlut`
- Programação gráfica 2D com `gluOrtho2D`

---

## ✨ Funcionalidades

- Renderização de uma paisagem com elementos 2D.
- Simulação da passagem do tempo com sol e lua.
- Transição visual entre dia e noite.
- Efeito de lua minguante com sobreposição de sombra.
- Interação do usuário com o teclado para controlar o tempo.
- Demonstração prática de conceitos de geometria 2D aplicados com OpenGL.

---

## 🏁 Como Executar

1. Clone este repositório:
   ```bash
   git clone https://github.com/Felipe-Araujo-duck/fazenda.git
