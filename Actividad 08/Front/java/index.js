function showSection(sectionId) {
    const sections = document.querySelectorAll('.section');
    sections.forEach(section => {
        section.classList.remove('active');
    });

    const activeSection = document.getElementById(sectionId);
    if (activeSection) {
        activeSection.classList.add('active');
    }
}


let id = 2


async function registrarTurno(event) {
    event.preventDefault(); 
    const cliente = document.getElementById("cliente").value;
    const hora = document.getElementById("hora").value;
    const fecha = document.getElementById("fecha").value;

    
    const data = {
        cliente: cliente,
        hora: hora,
        fecha: fecha,
        activo: true 
    };

    try {
        const response = await fetch("https://localhost:7227/Turnos/Insertar", {
            method: "POST",
            headers: {
                "Content-Type": "application/json"
            },
            body: JSON.stringify(data)
        });
        if (response.ok) {
            const result = await response.json();
            alert("Reserva guardada con éxito: " + JSON.stringify(result));
        } else {
            const error = await response.json();
            alert("Error al guardar la reserva: " + error.message);
        }
    } catch (error) {
        console.error("Error en la solicitud:", error);
        alert("Hubo un error al procesar la solicitud.");
    }
}

   


function valirdarTurno(event){
    const $nom = document.getElementById('nombre')
   //const $sug = document.getElementById('sugerencia')
    
    if($nom.value === ''){
        alert('Campo <NOMBRE> es requerido!')
        return;
    }
    // let email = $email.value
    // if( email.indexOf('@',0 )===-1){
    //     alert('Campo <EMAIL> no válido!')
    //     return;
    // }
    alert('Se enviaron los datos al servidor!')
}


async function consultar_Turnos(){

            const response = await fetch(`https://localhost:7227/Turnos/Recuperar`,{
                method: 'GET',  
                headers: {
                    'Content-Type': 'application/json', 
                },
            });
            if (!response.ok) {
                throw new Error('Error al obtener los datos de la API');
            }
    
            const turnos = await response.json();
            const $tbody = document.getElementById('MostartTurnos');
            let tbody = '';
            turnos.forEach(element => {
                tbody += `
                <tr>
                    <td>${element.cliente}</td>
                    <td>${element.hora}</td>
                    <td>${element.fecha}</td>
                </tr>`;
            });
            $tbody.innerHTML = tbody;
}
