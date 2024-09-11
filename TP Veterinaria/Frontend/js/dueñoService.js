function mostrarError(errorMsg){
    const errorDiv = document.createElement('div');
        errorDiv.className = 'alert';
        errorDiv.innerHTML = `
            <i class="fa-solid fa-circle-xmark"></i>
            <span>${errorMsg}</span>
        `;

    document.body.appendChild(errorDiv);

    const fadeOutTime = 4000; 

    setTimeout(function () {
        const alerts = document.querySelectorAll('.alert');
        alerts.forEach(alert => {
            alert.classList.add('fade-out');
        });

    }, fadeOutTime);
} 


/* detalle de dueño */
function mostrarFormularioModificar(dni, nombre){
    const modal = document.querySelector('#modificarDuenoModal');
    const form = modal.querySelector('#modificarDuenoForm');

    form.querySelector('input[name="dni"]').value = dni;
    form.querySelector('input[name="nombre"]').value = nombre;

    modal.showModal();
}


/* detalle dueño */
function mostrarFormularioDetalle(dni){
    const modal = document.querySelector('#detalleDuenoModal');
    const form = modal.querySelector('#detalleDuenoForm');


    fetch(`${baseurl}/api/duenos/Consultar?dni=${dni}`, {
        method: 'GET',
        headers: {
            'Content-Type': 'application/json'
        },
    })
    .then(response => response.json())
    .then(data => {
        form.querySelector('input[name="dni"]').value = data.dni;
        form.querySelector('input[name="nombre"]').value = data.nombre;
        modal.showModal();
    })
    .catch(error => {
        console.log('Error', error)
        mostrarError('No se pudo recuperar los datos del dueño.');
    })
    
}

/* detalle de dueño */
function mostrarFormularioEliminar(dni, nombre){
    const modal = document.querySelector('#eliminarDuenoModal');
    const form = modal.querySelector('#eliminarDuenoForm');

    form.querySelector('input[name="dni"]').value = dni;
    form.querySelector('input[name="nombre"]').value = nombre;

    modal.showModal();
}



const baseurl = 'http://localhost:5196'; 




/* cargar tabla de dueños */
document.addEventListener('DOMContentLoaded', () => {
    fetch(`${baseurl}/api/duenos/Lista`, {
        method: 'GET',
        headers: {
            'Content-Type': 'application/json'
        },
    })
    .then(response => response.json())
    .then(data => {
        const tableBody = document.querySelector('#tablaDuenos tbody');
        
        // Limpiar cualquier contenido previo
        tableBody.innerHTML = '';

        data.forEach(dueno => {
            const row = document.createElement('tr');
            row.innerHTML = `
                <td>${dueno.dni}</td>
                <td>${dueno.nombre}</td>
                <td class="table-action-btn">
                    <button class="action" onclick="mostrarFormularioModificar('${dueno.dni}', '${dueno.nombre}')">Modificar</button>
                    <span>|</span>
                    <button class="action" onclick="mostrarFormularioDetalle('${dueno.dni}')">Detalle</button>
                    <span>|</span>
                    <button class="action" onclick="mostrarFormularioEliminar('${dueno.dni}', '${dueno.nombre}')">Eliminar</button>
                </td>
            `;
            tableBody.appendChild(row);
        });
    })
    .catch(error => {
        console.log('Error', error)
        mostrarError('No se pudo cargar la lista de dueños.');
    })
});




/* crear dueño  */
document.getElementById('crearDuenoForm').addEventListener('submit', function (event) {
    event.preventDefault()

    const dni = document.querySelector('#crearDuenoForm input[name="dni"]').value;
    const nombre = document.querySelector('#crearDuenoForm input[name="nombre"]').value;

    
    const duenoNuevo = {
        Dni: dni,
        Nombre: nombre
    }

    fetch(`${baseurl}/api/duenos/Registrar`, {
        method: 'POST',
        headers: {
            'Content-Type': 'application/json'
        },
        body: JSON.stringify(duenoNuevo)
    })
    .then(response => {
        if (!response.ok){
            throw new Error('Error en la respuesta del servidor')
        }
        return;
    })
    .then(() => {
        alert('Dueño registrado con exito.')
        location.reload()
    })
    .catch(error => {
        console.log('Error', error);
        document.querySelector('#crearDuenoModal').close();
        mostrarError('No se pudo registrar el dueño.');
    })
})


/* modificar dueño */
document.getElementById('modificarDuenoForm').addEventListener('submit', function (event) {
    event.preventDefault()

    const dni = document.querySelector('#modificarDuenoForm input[name="dni"]').value;
    const nombre = document.querySelector('#modificarDuenoForm input[name="nombre"]').value;

    const duenoModificado = {
        Dni: dni,
        Nombre: nombre
    }

    fetch(`${baseurl}/api/duenos/Modificar`, {
        method: 'PUT',
        headers: {
            'Content-Type': 'application/json'
        },
        body: JSON.stringify(duenoModificado)
    })
    .then(response => {
        if (!response.ok) {
            throw new Error('Error en la respuesta del servidor');
        }
        return;
    })
    .then(() => {
        alert('Dueño modificado con éxito.');
        location.reload(); 
    })
    .catch(error => {
        console.log('Error', error);
        document.querySelector('#modificarDuenoModal').close();
        mostrarError('No se pudo modificar al dueño.');
    });
})




/* eliminar dueño */
document.getElementById('eliminarDuenoForm').addEventListener('submit', function (event) {
    event.preventDefault()
    const dni = document.querySelector('#eliminarDuenoForm input[name="dni"]').value;


    fetch(`${baseurl}/api/duenos/Eliminar?dni=${dni}`, {
        method: 'DELETE',
        headers: {
            'Content-Type': 'application/json'
        }
    })
    .then(response => {
        if (!response.ok) {
            throw new Error('Error en la respuesta del servidor');
        }
        return;
    })
    .then(() => {
        alert('Dueño eliminado con éxito.');
        location.reload(); 
    })
    .catch(error => {
        console.log('Error', error);
        document.querySelector('#eliminarDuenoModal').close();
        mostrarError('No se pudo eliminar el dueño.');
    });
})









