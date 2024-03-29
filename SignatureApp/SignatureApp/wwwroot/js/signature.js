initializeCanvas = (canvas) => {
    const ctx = canvas.getContext('2d');

    canvas.addEventListener('mousedown', (e) => {
        ctx.beginPath();
        isMouseDown = true;
    });

    canvas.addEventListener('mousemove', (e) => {
        if (isMouseDown) {
            const rect = canvas.getBoundingClientRect();
            const x = e.clientX - rect.left;
            const y = e.clientY - rect.top;

            ctx.lineTo(x, y);
            ctx.stroke();
        }
    });

    canvas.addEventListener('mouseup', (e) => {
        isMouseDown = false;
    });
};

getSignatureImage = (canvas) => {
    return canvas.toDataURL();
};

clearCanvas = (canvas) => {
    const ctx = canvas.getContext('2d');
    ctx.clearRect(0, 0, canvas.width, canvas.height);
};


downloadFile = (dataURL, filename) => {
    // Convert base64 to Blob
    const byteString = atob(dataURL.split(',')[1]);
    const mimeString = dataURL.split(',')[0].split(':')[1].split(';')[0];
    const ab = new ArrayBuffer(byteString.length);
    const ia = new Uint8Array(ab);
    for (let i = 0; i < byteString.length; i++) {
        ia[i] = byteString.charCodeAt(i);
    }
    const blob = new Blob([ab], { type: mimeString });

    // Create anchor element and trigger download
    const link = document.createElement('a');
    link.href = window.URL.createObjectURL(blob);
    link.download = filename;
    link.click();
};

changeColor = (canvas, color) => {
    const ctx = canvas.getContext('2d');
    ctx.strokeStyle = color;
};

setCanvasSize = (canvas, width, height) => {
    canvas.width = width;
    canvas.height = height;
};