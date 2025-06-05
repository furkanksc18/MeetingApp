$(document).ready(function() {
    $('#registerForm').on('submit', function(e) {
        e.preventDefault();
        
        // Form validation
        let isValid = true;
        const form = $(this);
        
        // Clear previous error messages
        $('.text-danger').text('');
        
        // Validate required fields
        form.find('input[required]').each(function() {
            if (!$(this).val()) {
                isValid = false;
                $(this).next('.text-danger').text('Bu alan zorunludur.');
            }
        });
        
        // Validate email format
        const email = form.find('input[type="email"]');
        if (email.val() && !isValidEmail(email.val())) {
            isValid = false;
            email.next('.text-danger').text('Geçerli bir e-posta adresi giriniz.');
        }
        
        // Validate phone number
        const phone = form.find('input[type="tel"]');
        if (phone.val() && !phone.val().match(/^[0-9]{10}$/)) {
            isValid = false;
            phone.next('.text-danger').text('Geçerli bir telefon numarası giriniz (10 haneli).');
        }
        
        // Validate age
        const age = form.find('input[type="number"]');
        if (age.val() && (age.val() < 18)) {
            isValid = false;
            age.next('.text-danger').text('Yaş 18\'den küçük olamaz.');
        }
        
        // Validate password length
        const password = form.find('input[type="password"]');
        if (password.val() && password.val().length < 6) {
            isValid = false;
            password.next('.text-danger').text('Şifre en az 6 karakter olmalıdır.');
        }
        
        if (isValid) {
            form[0].submit();
        }
    });
    
    function isValidEmail(email) {
        const re = /^[^\s@]+@[^\s@]+\.[^\s@]+$/;
        return re.test(email);
    }
}); 