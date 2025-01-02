let classes = [];

function openModal() {
    document.getElementById('modal').style.display = 'block';
}

function closeModal() {
    document.getElementById('modal').style.display = 'none';
}

function createClass() {
    const className = document.getElementById('className').value;
    const school = document.getElementById('school').value;

    if (className && school) {
        classes.push({ className, school });
        closeModal();
        // Cập nhật giao diện để hiển thị lớp học mới
        // Bạn có thể thêm logic để hiển thị lớp học mới ở đây
    }
}