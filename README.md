# 🏫 Sistema de Gestión de Cursos ACME

Este proyecto es una **prueba técnica en C#** para gestionar cursos y estudiantes sin depender de una API o base de datos. Se ha implementado una solución escalable con **arquitectura por capas** siguiendo principios **SOLID** y buenas prácticas.

---

## 📌 1. Características del Proyecto
✅ Registro de estudiantes (solo adultos).  
✅ Registro de cursos con tarifa y fechas.  
✅ Inscripción de estudiantes con validación de pago.  
✅ Listado de cursos y estudiantes inscritos por fecha.  
✅ Implementado en **C# .NET 8** con pruebas automatizadas en **xUnit**.  

---

## ⚙️ 2. Instalación y Configuración

### **🔹 Prerrequisitos**
- Tener instalado **.NET SDK 6+** ➜ [Descargar aquí](https://dotnet.microsoft.com/en-us/download)
- Editor recomendado: **Visual Studio Code** o **Visual Studio 2022**

### **🔹 Pasos para Clonar y Ejecutar**
```sh
# Clonar el repositorio
git clone https://github.com/AdrianRamirez23/ACME.git
cd CourseManagementSolution

# Restaurar dependencias
dotnet restore

# Ejecutar aplicación de consola
dotnet run --project CourseManagement.Presentation.ConsoleApp
