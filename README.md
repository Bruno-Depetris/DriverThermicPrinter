# 🖨️ Printer Driver Manager

Sistema de gestión de impresoras térmicas para integración con aplicaciones web desarrollado por **Predits**.

## 📋 Descripción

Printer Driver Manager es un agente de impresión que corre en segundo plano y permite que aplicaciones web puedan imprimir documentos en impresoras térmicas locales mediante peticiones HTTP.

## ✨ Características

- 🖨️ Gestión de múltiples impresoras
- 🎨 Configuración de tipografía y tamaño de letra
- 💾 Guardado automático de configuración
- 🌐 API REST para integración web
- 🔔 Sistema de notificaciones
- 🎯 Interfaz intuitiva y moderna
- 🔒 Ejecuta en segundo plano desde la bandeja del sistema

## 🚀 Instalación

### Requisitos Previos

- Windows 7 o superior
- .NET Framework 4.7.2 o superior
- Al menos una impresora instalada en el sistema

### Pasos de Instalación

1. **Descargar la aplicación**
   - Descarga el archivo `PrinterDriverManager.exe`
   - Asegúrate de tener la carpeta `Assets` con el icono `predits.ico`

2. **Ejecutar por primera vez**
   - Doble clic en `PrinterDriverManager.exe`
   - Se minimizará a la bandeja del sistema (cerca del reloj)
   - Verás un icono con el logo de Predits

3. **Configuración inicial**
   - Haz clic derecho en el icono de la bandeja
   - Selecciona "🖨️ Configurar Impresora"
   - Sigue las instrucciones de configuración

## ⚙️ Configuración

### 1. Seleccionar Impresora

1. Abre la ventana de configuración (clic derecho → "🖨️ Configurar Impresora")
2. En la lista de **"Impresoras Disponibles"** verás todas las impresoras instaladas
3. Haz clic en la fila de la impresora que deseas usar
4. Haz clic en la columna **"Seleccionar"** (icono de check)
5. Verás la impresora seleccionada en el panel derecho

### 2. Configurar Tipografía

En el panel derecho encontrarás:

- **Tipo de fuente**: Selecciona la tipografía que prefieras
  - Recomendadas para impresoras térmicas: `Consolas`, `Courier New`
  - Disponibles: Arial, Segoe UI, Calibri, Times New Roman, etc.

- **Tamaño de la letra**: Elige el tamaño en puntos
  - Rango disponible: 6pt a 24pt
  - Recomendado: 10pt - 12pt

### 3. Guardar Configuración

- ✅ Los cambios se guardan **automáticamente**
- Recibirás una notificación cada vez que se guarde la configuración
- La configuración se mantiene entre reinicios

## 🌐 Uso desde Aplicaciones Web

### API REST

El servidor escucha en el puerto **12345** de tu máquina local.

#### Endpoint: Imprimir

```http
POST http://localhost:12345/print
Content-Type: text/plain

Tu texto a imprimir aquí
```

**Ejemplo con JavaScript (Fetch API):**

```javascript
async function imprimir(texto) {
    try {
        const response = await fetch('http://localhost:12345/print', {
            method: 'POST',
            headers: {
                'Content-Type': 'text/plain'
            },
            body: texto
        });
        
        const resultado = await response.json();
        console.log(resultado); // {status: "ok", message: "Impresión enviada correctamente"}
    } catch (error) {
        console.error('Error al imprimir:', error);
    }
}

// Usar la función
imprimir('Hola Mundo\nEsta es una prueba de impresión');
```

**Ejemplo con jQuery:**

```javascript
function imprimir(texto) {
    $.ajax({
        url: 'http://localhost:12345/print',
        type: 'POST',
        data: texto,
        contentType: 'text/plain',
        success: function(response) {
            console.log('Impresión exitosa:', response);
        },
        error: function(xhr, status, error) {
            console.error('Error al imprimir:', error);
        }
    });
}
```

**Ejemplo con cURL:**

```bash
curl -X POST http://localhost:12345/print \
  -H "Content-Type: text/plain" \
  -d "Texto de prueba para imprimir"
```

#### Endpoint: Estado del Servidor

```http
GET http://localhost:12345/status
```

**Respuesta:**

```json
{
    "status": "running",
    "printer": "HP LaserJet Pro"
}
```

**Ejemplo:**

```javascript
async function verificarEstado() {
    const response = await fetch('http://localhost:12345/status');
    const status = await response.json();
    console.log('Impresora actual:', status.printer);
}
```

## 📱 Uso de la Aplicación

### Icono de Bandeja del Sistema

Haz **clic derecho** en el icono para ver las opciones:

- 🖨️ **Configurar Impresora**: Abre la ventana de configuración
- 📁 **Abrir Carpeta**: Abre la carpeta donde está instalada la aplicación
- ℹ️ **Acerca de**: Muestra información sobre la aplicación
- ❌ **Salir**: Cierra la aplicación (requiere confirmación)

### Doble Clic

Haz **doble clic** en el icono de la bandeja para abrir rápidamente la ventana de configuración.

## 🔧 Solución de Problemas

### La aplicación no inicia

1. Verifica que tienes .NET Framework 4.7.2 o superior instalado
2. Ejecuta como administrador si es necesario
3. Verifica que el puerto 12345 no esté en uso por otra aplicación

### No aparecen impresoras

1. Verifica que tienes impresoras instaladas en Windows
2. Ve a: Panel de Control → Dispositivos e impresoras
3. Asegúrate de que las impresoras estén en estado "Listo"

### Las aplicaciones web no pueden imprimir

1. Verifica que el agente esté ejecutándose (icono en bandeja)
2. Verifica que estés usando la URL correcta: `http://localhost:12345/print`
3. Revisa la consola del navegador para ver errores
4. Algunos navegadores pueden bloquear peticiones a localhost por CORS

### Error "Impresora no válida"

1. Abre la configuración
2. Selecciona nuevamente la impresora de la lista
3. Verifica que la impresora esté encendida y conectada

### La configuración no se guarda

1. Verifica que tengas permisos de escritura en la carpeta de la aplicación
2. Ejecuta la aplicación como administrador
3. La configuración se guarda en: `%LOCALAPPDATA%\PrinterDriverManager\`

## 📝 Formato de Impresión

### Caracteres Especiales

Puedes usar estos caracteres en tu texto:

- `\n` - Nueva línea
- `\t` - Tabulación
- Caracteres UTF-8 estándar

### Ejemplo de Ticket

```javascript
const ticket = `
================================
        MI NEGOCIO S.A.
================================
Fecha: ${new Date().toLocaleDateString()}
Hora: ${new Date().toLocaleTimeString()}
--------------------------------
PRODUCTOS:
1x Producto A          $10.00
2x Producto B          $25.00
--------------------------------
SUBTOTAL:              $35.00
IVA (21%):              $7.35
--------------------------------
TOTAL:                 $42.35
================================
     ¡Gracias por su compra!
================================
`;

imprimir(ticket);
```

## 🔐 Seguridad

- La aplicación **solo** escucha en localhost (127.0.0.1)
- No acepta conexiones externas
- No guarda información sensible
- La configuración es local al usuario

## 🆘 Soporte

Si tienes problemas o preguntas:

1. Revisa esta documentación
2. Verifica los logs de la aplicación
3. Contacta a soporte técnico de Predits

## 📄 Licencia

Copyright © 2025 Predits. Todos los derechos reservados.

## 🔄 Actualizaciones

Para actualizar la aplicación:

1. Cierra el agente (clic derecho → Salir)
2. Reemplaza el archivo ejecutable
3. Inicia la aplicación nuevamente
4. Tu configuración se mantendrá

## 💡 Tips y Trucos

### Ejecutar al Inicio de Windows

1. Presiona `Win + R`
2. Escribe `shell:startup`
3. Crea un acceso directo de `PrinterDriverManager.exe` en esa carpeta

### Probar la Impresión

Usa este HTML para probar rápidamente:

```html
<!DOCTYPE html>
<html>
<head>
    <title>Prueba de Impresión</title>
</head>
<body>
    <h1>Prueba de Impresora</h1>
    <textarea id="texto" rows="10" cols="50">
Hola Mundo
Esta es una prueba
    </textarea>
    <br>
    <button onclick="imprimir()">Imprimir</button>
    
    <script>
        async function imprimir() {
            const texto = document.getElementById('texto').value;
            try {
                const response = await fetch('http://localhost:12345/print', {
                    method: 'POST',
                    body: texto
                });
                const result = await response.json();
                alert('Resultado: ' + result.message);
            } catch (error) {
                alert('Error: ' + error.message);
            }
        }
    </script>
</body>
</html>
```

### Verificar que el servidor está activo

Abre en tu navegador: `http://localhost:12345/status`

Deberías ver algo como:
```json
{"status":"running","printer":"Tu Impresora"}
```

---

**Desarrollado con ❤️ por Predits**

*Versión 1.0 - 2025*