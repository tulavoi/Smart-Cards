const tabs = [
    { label: 'Lớp học', key: 'CLASSES', path: '', selected: true },
    { label: 'Học phần', key: 'SETS', path: '/sets', selected: false },
    { label: 'Bài kiểm tra thử', key: 'PRACTICE_TESTS', path: '/practice-tests', selected: false },
    { label: 'Lời giải chuyên gia', key: 'EXPLANATIONS', path: '/explanations', selected: false },
    { label: 'Thư mục', key: 'FOLDERS', path: '/folders', selected: false }
];

function handleTabClick(tabKey) {
    tabs.forEach(tab => {
        tab.selected = tab.key === tabKey;
    });
    renderTabs();
    renderMainContent(tabKey);
}

function renderTabs() {
    const tabsContainer = document.getElementById('tabsContainer');
    tabsContainer.innerHTML = ''; // Xóa nội dung cũ

    tabs.forEach(tab => {
        const tabElement = document.createElement('button');
        tabElement.setAttribute('aria-label', tab.label);
        tabElement.setAttribute('tabindex', tab.selected ? "0" : "-1");
        tabElement.setAttribute('aria-selected', tab.selected);
        tabElement.setAttribute('role', 'tab');
        tabElement.className = `AssemblyTab btn btn-outline-primary ${tab.selected ? 'active' : ''}`;
        tabElement.innerText = tab.label;
        tabElement.onclick = () => handleTabClick(tab.key);
        tabsContainer.appendChild(tabElement);
    });
}

function renderMainContent(activeTab) {
    const mainContent = document.getElementById('mainContent');
    mainContent.innerHTML = `<p>Nội dung cho tab: ${activeTab}</p>`; // Thay thế bằng nội dung thực tế
}

// Khởi động
renderTabs();
renderMainContent('CLASSES'); 