window.ResetGamePopup = (totalScore) =>
{
    return new Promise((playAgain) =>
    {
        const swalWithBootstrapButtons = Swal.mixin({
            customClass: {
                confirmButton: 'btn btn-success m-2',
                cancelButton: 'btn btn-danger'
            },
            buttonsStyling: false
        })

        swalWithBootstrapButtons.fire({
            title: '🐍 Ready for the next round?',
            text: `Total Score: ${totalScore}`,
            icon: 'success',
            showCancelButton: true,
            confirmButtonText: 'Yes!',
            cancelButtonText: 'No!',
            reverseButtons: false
        }).then((result) =>
        {
            if (result.isConfirmed)
            {
                playAgain(true);
            }
            else if (result.dismiss === Swal.DismissReason.cancel)
            {
                swalWithBootstrapButtons.fire(
                    'Thank you for playing the game!',
                    'Game is designed and copyrighted by Rikam Palkar.',
                    'success'
                ).then((result) => {
                    if (result.isConfirmed) {
                        playAgain(false); 
                    }
                });
                
            }
        });
    });
}

function navigateToWebsite(url) {
    window.location.href = url;
}
