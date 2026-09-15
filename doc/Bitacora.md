Bitacora_00 = {
    fecha = '07-09-2026'
    titulo = "Plantilla"
    descripcion = "[que hice][problemas][soluciones][aprendizaje]"
};

Bitacora_01 = {
    fecha = '07-09-2026',
    titulo = "Relevamiento del proyecto",
    descripcion = "Basicamente vincule mi repositorio de archivos local con el de github y cree algunos repositorios. No sabia como pushear mi repo al que ya habia creado en github; entonces, con ayuda de Copilot, verifique el estado del repo local, configure mi usuario de git, vincule finalmente con el comando remote add oringin y pushee con el comando git push -u origin main. Con esto aprendi que: 
    - remote add = decirle a Git dónde está la copia en la nube.
    - push -u = subir y dejar linkeada la rama para el futuro.
    - ls-remote / fetch = mirar antes de pushear si hay algo que te podría generar conflicto."
};

Bitacora_02 = {
    fecha = '08-09-2026',
    titulo = "Estructura principal",
    descripcion = "El DDL quedo redactado; en base a eso, se terminaron de escribir los Models y las interfaces de repos. Llegue a tener un error de concepto y no implementaba las interfaces de repos a ninguna clase, por consecuencia llegando a tener conflicto a la hora de definir los services. Pero releyendo proyectos viejos y sus esquemas cree las clases de repositorios y en estas implemente las interfaces de repos. Esto quedandome como aprendizaje y esquema de proyectos."
}

Bitacora_03 = {
    fecha = '10-09-2026',
    titulo = 'Cimientos de logica de negocios y frontend',
    descripcion = "El service y el controler de Usuario fueron programados, al menos sus cimientos. Debido a que no hay conexion a la base de datos porque no hay base de datos, la logica de negocios casi que no influye en el flujo de datos: El sevice directamente llama al repo con los datos crudos, sin filtrar. Hasta no tener una BD u controladores mas solidos no puedo aplcar logica de negocios."
}

Bitacora_04 = {
    fecha = '14-09-2026',
    titulo = 'Services y Controllers',
    descripcion = "Ademas de terminar de crear y definir los controllers y services, ajuste ciertos tipos de datos (por ejemplo, algunos ObtenerTodos tenian en parametro tipos de datos incorrectos como ushort para posicion que es byte), diagrame el DER."
}

Bitacora_05 = {
    fecha = '15-09-2026',
    titulo = "Creacion de soluciones, xunits y csprojs",
    descripcion = "Hoy se crearon los csproj pertinentes, estos posteriormente integrados a las soluciones para crear las unidades de testeo de cada model; ademas de actualizar el DDL por recomendacion del profesor. Al principio, el orden de carpetas, soluciones y archivos de proyecto de cs se mezclaron un poco, pero reestructurando un poco los directorios (con src y test como principales integraciones) se pudieron crear las soluciones necesarias y justas, tanto para core como minimal."
}