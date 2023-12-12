var sidenav = document.getElementById("mySidenav");
var openBtn = document.getElementById("openBtn");
var closeBtn = document.getElementById("closeBtn");

openBtn.onclick = openNav;
closeBtn.onclick = closeNav;

/* Set the width of the side navigation to 250px */
function openNav() {
    sidenav.classList.add("active");
}

/* Set the width of the side navigation to 0 */
function closeNav() {
    sidenav.classList.remove("active");
}


// REFLECHIR PAYEMENT SI ON A LE TEMPS
// Utilisez votre clé publique Stripe
//var stripe = Stripe('sk_test_51OLUOYCrIsytqVYwpw2EYjy9ZXe1q21AfqMHkwKazlLKX3E1lubC9xgX3ptyI7XCpHtvoDRH63TfZkGd5t1K3KqR00YIl5ZUbI');

//// Gérez la soumission du formulaire
//var form = document.getElementById('form1');
//form.addEventListener('submit', function (event) {
//    event.preventDefault();

//    // Créez un token de carte et soumettez le formulaire
//    stripe.createToken('card', {
//        number: document.getElementById('<%= NumeroCarte.ClientID %>').value,
//        exp_month: document.getElementById('<%= MoisExpiration.ClientID %>').value,
//        exp_year: document.getElementById('<%= AnneeExpiration.ClientID %>').value,
//        cvc: document.getElementById('<%= CVC.ClientID %>').value
//    }).then(function (result) {
//        if (result.error) {
//            // Affichez les erreurs de validation de la carte
//            var errorElement = document.getElementById('Message');
//            errorElement.textContent = result.error.message;
//        } else {
//            // Ajoutez le token de carte au formulaire pour qu'il soit soumis côté serveur
//            var hiddenInput = document.createElement('input');
//            hiddenInput.setAttribute('type', 'hidden');
//            hiddenInput.setAttribute('name', 'stripeToken');
//            hiddenInput.setAttribute('value', result.token.id);
//            form.appendChild(hiddenInput);

//            // Soumettez le formulaire côté serveur
//            form.submit();
//        }
//    });
//});

