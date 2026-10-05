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

Bitacora_06 = {
    fecha = '17-09-2026',
    titulo = "Vinculacion de csprojs y reajustes"
}

Bitacora_07 = {
    fecha = '22-09-2026',
    titulo = "Logica de negocio en Models y preparacion de tests",
    descripcion = "Se releyo el enunciado y se incorporo comportamiento de dominio a los Models sin mezclar persistencia. Jugador valida su cotizacion, Puntuacion valida fecha y puntaje, Usuario valida la longitud fija de la contraseña almacenada, y Plantilla administra titulares, suplentes, presupuesto, formacion y puntaje por fecha. Tambien se corrigio el DDL para soportar hasta 2000 usuarios, usar la clave compuesta Fecha + IdJugador en Puntuacion y reforzar restricciones de datos. Se actualizaron los tests unitarios para probar reglas de negocio sin depender de MySQL, Repository o Service. Por ultimo, se dejaron preparados y vacios los archivos de tests de Repository y Service para completarlos cuando exista persistencia real."
}

<!-- Incidente de Git en main (28-09-2026)
Que paso: despues del apagado, Git mostraba todos los archivos con A y no podia cargar el graph. La causa tecnica que se pudo comprobar fue que .git/refs/heads/main contenia un hash de ceros; por eso HEAD apuntaba a una referencia invalida. No se perdieron los commits: el reflog local conservaba la secuencia y GitHub tenia main en 69bc842. Que el apagado durante el push haya causado directamente la referencia rota es una explicacion probable, no algo que se pueda probar solo con esos datos.

Como reconocerlo (PowerShell, parado en la carpeta del repositorio):
    git status --short --branch
    git log --oneline --decorate --graph -10
    git fsck --full --no-reflogs
    git reflog show --all
    git ls-remote origin main
Si status muestra muchos A, pero Git log informa "bad object refs/heads/main" o "failed to resolve HEAD", no asumir que todos los archivos son nuevos y no ejecutar reset --hard, git clean ni push --force. fsck puede señalar una referencia invalida; reflog ayuda a recuperar los hashes previos; ls-remote confirma el hash publicado en GitHub.

Recuperacion usada: respaldar el archivo local roto fuera de refs, restaurar main al hash comprobado del remoto, traer la referencia remota y verificar status y graph. En este caso, el archivo roto se guardo como .git/main-ref-corrupt-backup; main se restauro a 69bc842 y luego se ejecuto git fetch origin. Despues, status quedo en main...origin/main y solo marco M en scripts/01 SP.sql, un cambio local real que se preservo. Los comandos exactos para un caso equivalente, despues de confirmar que el remoto apunta al commit correcto y que git cat-file -e <HASH>^{commit} no da error, son:
    Move-Item .git\refs\heads\main .git\main-ref-corrupt-backup
    git update-ref refs/heads/main <HASH>
    git fetch origin
    git status --short --branch
    git log --oneline --decorate --graph -10
Reemplazar <HASH> por el hash completo obtenido con git ls-remote origin main. Si ese archivo de referencia no existe o la rama tiene otro nombre, detenerse y revisar antes de mover o crear referencias. -->

Bitacora_08 = {
    fecha = '28-09-2026',
    titulo = "Tests de Models y conexion MySQL",
    descripcion = "Rehice los tests de Models para probar los metodos de validacion y las reglas de dominio que implementa cada clase. En PlantillaTitular y PlantillaSuplente, que no tienen metodos propios, deje pruebas simples de sus propiedades. Tambien simplifique el test de conexion a un Fact comun. Los tests de integracion requieren MySQL activo y GRAN_ET12_CONNECTION_STRING configurada. Entonces Marque los tests de repositorio como Integration y deje los tests unitarios separables por categoria. Aprendi que un test debe comprobar comportamiento existente en la clase, y una prueba de conexion permite confirmar que se pudo abrir el enlace con MySQL."
};

Bitacora_09 = {
    fecha = '05-10-26',
    titulo = "Complicando controllers y simplificando encriptacion"
    descripcion = "Catchtrye los controllers y simplifique la encriptacion de contraseña en la capa de servicio con ByCrypt, como tenia antes. Antes me podia llegar a explotar el programa en el frontend, ahora con los catch en la capa de controller simplemente me da una excepcion. Aprendi los tipos de errores en http, porqu necesitaba hacer el condicional en el catch:
    - 500: Errores en la capa de datos o lógica interna
    - 400: Errores de validación o argumentos incorrectos
    Y que menos es mas, con encriptar la contrasña en el hash de 60 es bastntito mas que suficiente (Ademas asi lo pidio el profe)."
}