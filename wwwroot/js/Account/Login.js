$(document).ready(function() {
    $('form').on('submit', function(e) {
        e.preventDefault();
        
        // Form validation
        let isValid = true;
        const form = $(this);
        
        // Clear previous error messages
        $('.validation-error').text('');
        
        // Validate email
        const email = form.find('input[type="email"]');
        if (!email.val()) {
            isValid = false;
            email.next('.validation-error').text('E-posta adresi zorunludur.');
        } else if (!isValidEmail(email.val())) {
            isValid = false;
            email.next('.validation-error').text('Geçerli bir e-posta adresi giriniz.');
        }
        
        // Validate password
        const password = form.find('input[type="password"]');
        if (!password.val()) {
            isValid = false;
            password.next('.validation-error').text('Şifre zorunludur.');
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