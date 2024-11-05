document.addEventListener("DOMContentLoaded", () => {
    let currentPlayer = 'X';

    document.querySelectorAll(".cell").forEach(cell => {
        cell.addEventListener("mouseenter", hoverMark);
        cell.addEventListener("mouseleave", removeHoverMark);
        cell.addEventListener("click", clickMark);
    });

    function hoverMark(event) {
        if (!event.target.classList.contains('clicked-X') && !event.target.classList.contains('clicked-O')) {
            event.target.classList.add(currentPlayer === 'X' ? 'hover-X' : 'hover-O');
        }
    }

    function removeHoverMark(event) {
        event.target.classList.remove('hover-X', 'hover-O');
    }

    function clickMark(event) {
        if (!event.target.classList.contains('clicked-X') && !event.target.classList.contains('clicked-O')) {
            event.target.classList.remove('hover-X', 'hover-O'); 
            event.target.classList.add(currentPlayer === 'X' ? 'clicked-X' : 'clicked-O');
            var cellId = event.target.id;
            savePlay(cellId, currentPlayer);
            currentPlayer = currentPlayer === 'X' ? 'O' : 'X'; 
        }
    }

    function savePlay(cellId, player) {
        let url = player === 'X' ? '/TicTacToe/SavePlay1' : '/TicTacToe/SavePlay2';
        let data = { cellId: cellId, player: player };

        fetch(url, {
            method: 'POST',
            headers: {
                'Content-Type': 'application/json'
            },
            body: JSON.stringify(data)
        })
            .then(response => {
                if (!response.ok) {
                    throw new Error('Network response was not ok');
                }
                return response.json();
            })
            .catch(error => {
                console.error('There has been a problem with your fetch operation:', error);
            });
    }
});
