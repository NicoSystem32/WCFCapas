$(function () {
    $("#user-form").submit(function (e) {

        e.preventDefault();

        var name = $("#nombre").val();
        var dateOfBirth = $("#date-birth").val();
        var gender = $("#gender").val();

        var userToInsert = {
            Name: name,
            DateOfBirth: dateOfBirth,
            Gender: gender
        };

        fetch('/Users/InsertUser', {
            method: 'POST',
            body: JSON.stringify(userToInsert),
            headers: {
                'Content-Type': 'application/json'
            }
        })
            .then(response => response.json())
            .then(data => {
                if (data.success) {
                    Swal.fire({
                        title: 'User created successfully',
                        icon: 'success'
                    }).then(() => {
                        location.href = '/Users/UserManagement';
                    });
                } else {
                    Swal.fire({
                        title: 'Error',
                        text: data.message,
                        icon: 'error'
                    });
                }
            })
            .catch(error => {
                Swal.fire({
                    title: 'Error',
                    text: error.message,
                    icon: 'error'
                });
            });
    });
});


$(function () {
    $("#user-form-update").submit(function (event) {
        event.preventDefault(); 
        var form = $(this);
        var url = '/Users/EditUser';
        var formData = form.serialize();

        const params = new URLSearchParams(formData);
        const formDataConvert = Object.fromEntries(params.entries());


        var userToEdit = {
            
            UserId: formDataConvert.id,
            Name: formDataConvert.nombre,
            DateOfBirth: formDataConvert.dateBirth,
            Gender: formDataConvert.genderU

        };
        
        Swal.fire({
            title: 'Are you sure you want to update this user?',
            showDenyButton: true,
            confirmButtonText: 'Sí',
            denyButtonText: 'No',
        }).then((result) => {
            if (result.isConfirmed) {
                fetch(url, {
                    method: 'POST',
                    body: JSON.stringify(userToEdit),
                    headers: {
                        'Content-Type': 'application/json'
                    }
                })
                    .then(response => response.json())
                    .then(data => {
                        if (data.success) {
                            Swal.fire({
                                title: data.message,
                                icon: 'success',
                                timer: 2000
                            });
                            console.log(data);
                            window.location.href = '/Users/UserManagement';
                        } else {
                            Swal.fire({
                                title: 'Error',
                                text: data.message,
                                icon: 'error',
                                timer: 2000
                            });
                            console.log(data);
                        }
                    })
                    .catch(error => console.log(error));
            } else if (result.isDenied) {
                Swal.fire('The changes have not been saved.', '', 'info');
            }
        });

    });
});


function deleteUser(userId) {

    Swal.fire({
        title: 'Are you sure you want to delete this user?',
        showDenyButton: true,
        showCancelButton: true,
        confirmButtonText: 'Yes',
        denyButtonText: `No`,
    }).then((result) => {
        
        if (result.isConfirmed) {
            fetch('/Users/DeleteUser', {
                method: 'POST',
                body: JSON.stringify({ userIdToDelete: userId }),
                headers: {
                    'Content-Type': 'application/json',
                    /*'RequestVerificationToken': document.getElementsByName("__RequestVerificationToken")[0].value*/
                }
            })
                .then(response => response.json())
                .then(data => {
                    if (data.success) {
                        Swal.fire('Success!', data.message, 'success');
                        location.reload();
                    } else {
                        Swal.fire('Error!', data.message, 'error');
                    }
                })
                .catch(error => console.log(error));
        } else if (result.isDenied) {
            Swal.fire('User not deleted', '', 'info')
        }
    })

}
