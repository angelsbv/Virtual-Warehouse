int = document.querySelectorAll('.int')
int
    .forEach(t => {
        t.addEventListener('keyup', (e) => {
            for (i = 0; i < int.length; i++) {
                if (int[i].value < 1) {
                    int[i].value = 1;
                }
            }
        });
    });

function checkInt() {
    for (i = 0; i < int.length; i++) {
        if (int[i].value < 1) {
            int[i].value = 1;
        }
    }
}