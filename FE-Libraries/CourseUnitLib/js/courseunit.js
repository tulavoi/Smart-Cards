let courseUnits = [];
let isDropdownOpen = false;
let selectedFilter = 'Gần đây';

function toggleDropdown() {
    isDropdownOpen = !isDropdownOpen;
    document.getElementById('dropdownMenu').style.display = isDropdownOpen ? 'block' : 'none';
}

function handleFilterSelect(filter) {
    selectedFilter = filter;
    document.getElementById('selectedFilter').innerText = selectedFilter;
    isDropdownOpen = false;
    document.getElementById('dropdownMenu').style.display = 'none';
    // Thêm logic lọc ở đây
}

function handleCreateClick() {
    // Logic để điều hướng đến trang tạo học phần
    window.location.href = '/course-unit';
}

// Hàm để thêm học phần mới
function addCourseUnit(newCourseUnit) {
    courseUnits.push(newCourseUnit);
    renderCourseUnits();
}

function renderCourseUnits() {
    const container = document.getElementById('courseUnitsContainer');
    container.innerHTML = ''; // Xóa nội dung cũ

    if (courseUnits.length > 0) {
        courseUnits.forEach((unit) => {
            const unitElement = document.createElement('div');
            unitElement.innerHTML = `
                <div class="courseunitlib-content-courseunitpreview card">
                    <h3 class="unit-name">${unit.unitName}</h3>
                    <p class="description">${unit.description}</p>
                    <span class="terms-count">${unit.termsCount} học phần</span>
                </div>
            `;
            container.appendChild(unitElement);
        });
    } else {
        const emptyState = document.querySelector('.empty-state');
        emptyState.style.display = 'block';
        container.appendChild(emptyState);
    }
}