function handleJoinClick(event, isAuthenticated) {
    if (!isAuthenticated) {
        event.preventDefault();
        if (confirm('Bu toplantıya katılmak için giriş yapmanız gerekiyor. Giriş yapmak ister misiniz?')) {
            window.location.href = '/Account/Login';
        }
    }
    else {
        event.preventDefault();
        const joinUrl = event.currentTarget.getAttribute('href');
        if (confirm('Bu toplantıya katılmak istediğinizden emin misiniz?')) {
            window.location.href = joinUrl;
        }
    }
}

function handleJoinHover(event, isAuthenticated) {
    if (!isAuthenticated) {
        const tooltip = document.createElement('div');
        tooltip.className = 'join-tooltip';
        tooltip.textContent = 'Katılmak için giriş yapmalısınız';
        
        // Tooltip'i butonun üzerine yerleştir
        const button = event.currentTarget;
        const rect = button.getBoundingClientRect();
        tooltip.style.top = (rect.top - 30) + 'px';
        tooltip.style.left = (rect.left + (rect.width / 2) - 100) + 'px';
        
        // Eğer zaten bir tooltip varsa kaldır
        const existingTooltip = document.querySelector('.join-tooltip');
        if (existingTooltip) {
            existingTooltip.remove();
        }
        
        document.body.appendChild(tooltip);
    }
}

function handleJoinLeave() {
    const tooltip = document.querySelector('.join-tooltip');
    if (tooltip) {
        tooltip.remove();
    }
} 