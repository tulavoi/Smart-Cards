// Xử lý lật thẻ khi click
document.querySelectorAll('.vocabulary-card').forEach((card) => {
    card.addEventListener('click', () => {
        card.classList.toggle('flipped');
    });
});

//  Xử lý nút bấm qua lại giữa các thẻ
document.addEventListener('DOMContentLoaded', function () {
    // Lấy tất cả các thẻ vocabulary
    const cards = document.querySelectorAll('.vocabulary-card');
    const nextBtn = document.querySelector('.control-button.right'); // Nút "next"
    const prevBtn = document.querySelector('.control-button.left'); // Nút "previous"

    let currentIndex = 0; // Chỉ số hiện tại của thẻ vocabulary card

    // Hàm để cập nhật trạng thái hiển thị của các thẻ
    function updateCards() {
        cards.forEach((card, index) => {
            // Ẩn tất cả các thẻ trừ thẻ đang hiển thị
            if (index === currentIndex) {
                card.classList.remove('d-none');
            } else {
                card.classList.add('d-none');
            }
        });
    }

    // Hàm điều khiển nhấn vào nút "next"
    nextBtn.addEventListener('click', function () {
        // Nếu chưa đến cuối danh sách thẻ, chuyển sang thẻ tiếp theo
        if (currentIndex < cards.length - 1) {
            currentIndex++;
            updateCards(); // Cập nhật hiển thị thẻ
        }
    });

    // Hàm điều khiển nhấn vào nút "prev"
    prevBtn.addEventListener('click', function () {
        // Nếu chưa ở đầu danh sách, quay lại thẻ trước đó
        if (currentIndex > 0) {
            currentIndex--;
            updateCards(); // Cập nhật hiển thị thẻ
        }
    });

    // Ban đầu cập nhật hiển thị các thẻ
    updateCards();
});
