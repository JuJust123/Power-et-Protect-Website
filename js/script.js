document.addEventListener("DOMContentLoaded", function () {
    // Sélection de l'image "trousse" (remplace "id-de-ton-image" par le bon ID ou class)
    const trousseImage = document.querySelector("#momo"); // Remplace ID par l'identifiant réel
    const popup = document.getElementById("popup");
    const closeBtn = document.querySelector(".close-btn");

    // Ouvrir le popup au clic sur l’image
    trousseImage.addEventListener("click", function () {
        popup.style.display = "flex";
    });

    // Fermer le popup au clic sur le bouton de fermeture
    closeBtn.addEventListener("click", function () {
        popup.style.display = "none";
    });

    // Fermer aussi si on clique en dehors du popup
    popup.addEventListener("click", function (event) {
        if (event.target === popup) {
            popup.style.display = "none";
        }
    });
});

document.addEventListener("DOMContentLoaded", function () {
    // Sélection de l'image "trousse" (remplace "id-de-ton-image" par le bon ID ou class)
    const trousseImage = document.querySelector("#momo2"); // Remplace ID par l'identifiant réel
    const popup = document.getElementById("popup");
    const closeBtn = document.querySelector(".close-btn");

    // Ouvrir le popup au clic sur l’image
    trousseImage.addEventListener("click", function () {
        popup.style.display = "flex";
    });

    // Fermer le popup au clic sur le bouton de fermeture
    closeBtn.addEventListener("click", function () {
        popup.style.display = "none";
    });

    // Fermer aussi si on clique en dehors du popup
    popup.addEventListener("click", function (event) {
        if (event.target === popup) {
            popup.style.display = "none";
        }
    });
});
