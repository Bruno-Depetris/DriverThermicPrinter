# 🖨️ Driver Impresora Térmica - PREDITS

[![.NET Framework](https://img.shields.io/badge/.NET%20Framework-4.7.2+-blue.svg)](https://dotnet.microsoft.com/)
[![License](https://img.shields.io/badge/license-MIT-green.svg)](LICENSE)
[![Windows](https://img.shields.io/badge/platform-Windows-lightgrey.svg)](https://www.microsoft.com/windows)

Sistema de gestión de impresoras térmicas para integración con aplicaciones web mediante API REST local.

## 📋 Descripción

Driver Impresora Térmica es una aplicación de escritorio que actúa como puente entre aplicaciones web y impresoras térmicas locales. Permite a sistemas web enviar trabajos de impresión directamente a impresoras térmicas sin necesidad de diálogos de impresión del navegador.

## ✨ Características

- 🚀 **API REST Local** - Servidor HTTP en localhost para recepción de trabajos de impresión
- 🔧 **Configuración Sencilla** - Interfaz gráfica para selección de impresora y puerto
- 📊 **Verificación de Estado** - Endpoint para comprobar conectividad y estado del driver
- 🎨 **Fuente Personalizable** - Configuración de tipo y tamaño de fuente
- 🔄 **Puerto Dinámico** - Cambio de puerto sin reiniciar aplicación
- 💾 **Configuración Persistente** - Guarda preferencias entre sesiones
- 🎯 **Bandeja del Sistema** - Ejecución en segundo plano con acceso rápido
- 🔒 **CORS Configurable** - Soporte para integración segura con aplicaciones web

## 🎯 Casos de Uso

- Sistemas POS (Punto de Venta)
- Aplicaciones de ticketing
- Sistemas de gestión de pedidos
- Aplicaciones de control de inventario
- Cualquier sistema web que requiera impresión directa

## 📦 Requisitos del Sistema

- **Sistema Operativo:** Windows 7 / 8 / 10 / 11
- **.NET Framework:** 4.7.2 o superior
- **Memoria RAM:** 256 MB mínimo
- **Espacio en Disco:** 10 MB
- **Permisos:** Acceso a impresoras del sistema

## 🚀 Instalación

### Instalación Básica

1. Descarga el instalador `DriverThermicPrinter-Setup.exe` desde [Releases](releases)
2. Ejecuta el instalador
3. Sigue las instrucciones del asistente de instalación
4. La aplicación se iniciará automáticamente al finalizar

### Instalación Portable

1. Descarga `DriverThermicPrinter-Portable.zip`
2. Extrae el contenido en una carpeta de tu elección
3. Ejecuta `DriverThermicPrinter.exe`

## ⚙️ Configuración

### Primera Vez

1. Al iniciar, la aplicación aparecerá en la bandeja del sistema (system tray)
2. Haz clic derecho en el icono y selecciona **"Configurar Impresora"**
3. Selecciona tu impresora térmica de la lista
4. Configura el puerto deseado (por defecto: 55000)
5. Opcionalmente, ajusta la fuente de impresión
6. Haz clic en **"Guardar"**

### Cambio de Puerto

El driver soporta los siguientes puertos:
- 49152
- 50000
- 55000 (recomendado)
- 60000
- 65000

Para cambiar el puerto:
1. Abre la ventana de configuración
2. Selecciona el nuevo puerto del menú desplegable
3. Guarda los cambios
4. El servidor se reiniciará automáticamente en el nuevo puerto

## 🔌 API REST

### Endpoints Disponibles

#### 1. Verificar Estado
```http
GET http://localhost:55000/status
```

**Respuesta Exitosa:**
```json
{
  "status": "running",
  "printer": "Nombre de la Impresora"
}
```

#### 2. Imprimir Texto
```http
POST http://localhost:55000/print
Content-Type: text/plain

Texto a imprimir...
```

**Respuesta Exitosa:**
```json
{
  "status": "ok",
  "message": "Impresión enviada correctamente"
}
```

**Respuesta de Error:**
```json
{
  "status": "error",
  "message": "Error al imprimir"
}
```

### Ejemplos de Integración

#### JavaScript / Fetch API
```javascript
// Verificar estado
async function verificarImpresora() {
  const response = await fetch('http://localhost:55000/status');
  const data = await response.json();
  console.log(data);
}

// Imprimir texto
async function imprimir(texto) {
  const response = await fetch('http://localhost:55000/print', {
    method: 'POST',
    headers: { 'Content-Type': 'text/plain' },
    body: texto
  });
  const result = await response.json();
  return result;
}
```

#### jQuery
```javascript
// Imprimir ticket
$.ajax({
  url: 'http://localhost:55000/print',
  method: 'POST',
  contentType: 'text/plain',
  data: 'Mi ticket de impresión',
  success: function(response) {
    console.log('Impreso:', response);
  }
});
```

#### C# / HttpClient
```csharp
using (var client = new HttpClient())
{
    var content = new StringContent("Texto a imprimir", Encoding.UTF8, "text/plain");
    var response = await client.PostAsync("http://localhost:55000/print", content);
    var result = await response.Content.ReadAsStringAsync();
}
```

#### Python / Requests
```python
import requests

# Verificar estado
response = requests.get('http://localhost:55000/status')
print(response.json())

# Imprimir
response = requests.post(
    'http://localhost:55000/print',
    data='Texto a imprimir'.encode('utf-8'),
    headers={'Content-Type': 'text/plain'}
)
print(response.json())
```

## 🛡️ Seguridad

### CORS (Cross-Origin Resource Sharing)

El driver incluye soporte CORS para permitir peticiones desde navegadores web. Por defecto, acepta peticiones de cualquier origen en localhost.

Para producción, se recomienda configurar orígenes específicos modificando el código fuente:

```csharp
string[] origenesPermitidos = { 
    "https://tuapp.com",
    "https://www.tuapp.com"
};
```

### Consideraciones de Seguridad

- ⚠️ El servidor solo escucha en `localhost`, no es accesible desde la red
- ⚠️ No se recomienda exponer el puerto a través de firewall
- ✅ Para producción, implementa autenticación mediante API Keys
- ✅ Valida el tamaño y contenido de las impresiones
- ✅ Implementa rate limiting para evitar abuso

## 📁 Estructura de Archivos

```
DriverThermicPrinter/
├── DriverThermicPrinter.exe          # Ejecutable principal
├── Assets/
│   └── predits.ico                    # Icono de la aplicación
├── Forms/
│   ├── Form_Configurar.cs             # Ventana de configuración
│   └── Notificacion/
│       └── msj.cs                     # Sistema de notificaciones
├── PrinterServer.cs                   # Servidor HTTP
├── TrayAppContext.cs                  # Gestión de bandeja del sistema
└── ConfigurarPuerto.cs                # Gestión de configuración

%AppData%/DriverThermicPrinter/
└── config.txt                         # Archivo de configuración
```

## 🔧 Configuración Avanzada

### Archivo de Configuración

Ubicación: `%AppData%\DriverThermicPrinter\config.txt`

```
PORT=55000
```

### Modificar Puertos Disponibles

Edita el archivo `ConfigurarPuerto.cs`:

```csharp
public int[] Puertos = new int[] { 49152, 50000, 55000, 60000, 65000 };
```

## 🐛 Solución de Problemas

### La aplicación no se conecta

1. Verifica que el driver esté ejecutándose (icono en bandeja del sistema)
2. Confirma el puerto correcto en la configuración
3. Verifica que no haya otro programa usando el mismo puerto
4. Abre símbolo del sistema y ejecuta: `netstat -ano | findstr :55000`

### Error "Puerto en uso"

- Cierra otras instancias de la aplicación
- Cambia a un puerto diferente en la configuración
- Verifica con Task Manager que no hay procesos huérfanos

### La impresora no imprime

1. Verifica que la impresora esté seleccionada correctamente en configuración
2. Comprueba que la impresora esté encendida y conectada
3. Prueba imprimir desde otra aplicación para verificar drivers
4. Revisa que la impresora no esté en modo "Offline"

### Problemas de CORS

Si recibes errores CORS desde tu aplicación web:

1. Verifica que estés usando `http://localhost` (no `127.0.0.1`)
2. Asegúrate de incluir headers CORS en el servidor
3. Para aplicaciones web externas, configura orígenes permitidos

## 📝 Formato de Tickets

### Ejemplo de Ticket Básico

```
================================
       MI NEGOCIO
================================
Fecha: 27/10/2025
Hora: 14:30:00
--------------------------------
Item         Cant    Precio
--------------------------------
Producto 1     2     $10.00
Producto 2     1     $15.00
--------------------------------
             TOTAL:   $35.00
================================
  ¡Gracias por su compra!
================================
```

### Caracteres Especiales

La impresora soporta caracteres ASCII estándar. Para mejor compatibilidad:
- Usa fuentes monoespaciadas (Consolas, Courier New)
- Evita caracteres Unicode complejos
- Limita el ancho a 32-48 caracteres según tu impresora

## 🤝 Contribuciones

Las contribuciones son bienvenidas. Por favor:

1. Fork el proyecto
2. Crea una rama para tu feature (`git checkout -b feature/AmazingFeature`)
3. Commit tus cambios (`git commit -m 'Add some AmazingFeature'`)
4. Push a la rama (`git push origin feature/AmazingFeature`)
5. Abre un Pull Request

## 📄 Licencia

Este proyecto está bajo la Licencia MIT - ver el archivo [LICENSE](LICENSE) para más detalles.

## 👥 Autores

* **PREDITS** - *Desarrollo Inicial* - [PREDITS](https://github.com/predits)

## 🙏 Agradecimientos

* A la comunidad de desarrollo de impresoras térmicas
* A todos los contribuidores del proyecto
* A los usuarios que reportan bugs y sugieren mejoras

## 📞 Soporte

- 📧 Email: soporte@predits.com
- 🌐 Web: https://predits.com
- 📝 Issues: [GitHub Issues](https://github.com/predits/driver-thermic-printer/issues)

## 🗺️ Roadmap

- [ ] Soporte para imágenes y logos
- [ ] Dashboard web de administración
- [ ] Soporte para múltiples impresoras simultáneas
- [ ] Sistema de colas de impresión
- [ ] Logs detallados de actividad
- [ ] Soporte para comandos ESC/POS
- [ ] Actualización automática
- [ ] Instalador MSI profesional

## 📊 Changelog

### v1.0.0 (2025-10-27)
- 🎉 Versión inicial
- ✅ API REST básica
- ✅ Configuración de impresora
- ✅ Soporte CORS
- ✅ Cambio dinámico de puerto
- ✅ Interfaz de bandeja del sistema

---

**Hecho con ❤️ por PREDITS** | © 2025 Todos los derechos reservados