const ClassroomContent = () => {
    return `<div class="classroom-content">Nội dung lớp học</div>`;
};

const CourseUnitContent = () => {
    return `<div class="courseunit-content">Nội dung học phần</div>`;
};

const PracticeTestContent = () => {
    return `<div class="practicetest-content">Nội dung bài kiểm tra thử</div>`;
};

const ExpertContent = () => {
    return `<div class="expert-content">Nội dung lời giải chuyên gia</div>`;
};

const FolderContent = () => {
    return `<div class="folder-content">Nội dung thư mục</div>`;
};

function renderContent(activeTab) {
    const contentContainer = document.getElementById('contentContainer');
    contentContainer.innerHTML = ''; // Xóa nội dung cũ

    switch(activeTab) {
        case 'CLASSES':
            contentContainer.innerHTML = ClassroomContent();
            break;
        case 'SETS':
            contentContainer.innerHTML = CourseUnitContent();
            break;
        case 'PRACTICE_TESTS':
            contentContainer.innerHTML = PracticeTestContent();
            break;
        case 'EXPLANATIONS':
            contentContainer.innerHTML = ExpertContent();
            break;
        case 'FOLDERS':
            contentContainer.innerHTML = FolderContent();
            break;
        default:
            contentContainer.innerHTML = `
                <div class="empty-state">
                    <img src="path/to/empty-state-image.svg" alt="Không có nội dung"/>
                    <div class="title">Không có nội dung</div>
                    <div class="description">Vui lòng chọn một tab để xem nội dung.</div>
                </div>`;
    }
}

// Khởi động với tab mặc định
renderContent('CLASSES'); 