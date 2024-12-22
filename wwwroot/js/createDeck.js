document.querySelector('.add-card').addEventListener('click', () => {
    const termsSection = document.getElementById('terms-section');
    const termItemCount = document.getElementById('term-item-count');
    var countNumber = parseInt(termItemCount.innerText || termItemCount.textContent); // Lấy nội dung text (số) trong phần tử span
    countNumber++;
    termItemCount.innerText = countNumber; // Cập nhật lại stt trong term-item-count
    const newCard = `<div class="term-item mb-3 border-0 rounded-3 p-3">
                    <div class="row align-items-center">
                        <div class="col mb-3">
                            <span id="term-item-count" class="text-secondary fw-bold fs-6">${countNumber}</span>
                            <hr />
                        </div>
                        <div class="row">
                            <div class="col-5">
                                <input type="text" class="custom-input">
                                <span class="fw-bold text-secondary" style="font-size: 10px;">THUẬT NGỮ</span>
                            </div>
                            <div class="col-5">
                                <input type="text" class="custom-input">
                                <span class="fw-bold text-secondary" style="font-size: 10px;">ĐỊNH NGHĨA</span>
                            </div>
                            <div class="col-2 text-end">
                                <button class="btn-img btn btn-light border">
                                    <i class="icon-img fa-regular fa-image"></i><br />
                                    Hình ảnh
                                </button>
                            </div>
                        </div>
                    </div>
                </div>`;
    termsSection.insertAdjacentHTML('beforeend', newCard);
});

