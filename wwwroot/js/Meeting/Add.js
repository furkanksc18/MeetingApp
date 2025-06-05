$(document).ready(function() {
    $('form').on('submit', function(e) {
        e.preventDefault();
        
        // Form validation
        let isValid = true;
        const form = $(this);
        
        // Clear previous error messages
        $('.validation-message').text('');
        
        // Validate meeting name
        const name = form.find('input[type="text"]').first();
        if (!name.val()) {
            isValid = false;
            name.next('.validation-message').text('Toplantı başlığı zorunludur.');
        }
        
        // Validate meeting type
        const type = form.find('select');
        if (!type.val()) {
            isValid = false;
            type.next('.validation-message').text('Toplantı türü seçilmelidir.');
        }
        
        // Validate location
        const location = form.find('input[type="text"]').last();
        if (!location.val()) {
            isValid = false;
            location.next('.validation-message').text('Buluşma yeri zorunludur.');
        }
        
        // Validate date
        const date = form.find('input[type="datetime-local"]');
        if (!date.val()) {
            isValid = false;
            date.next('.validation-message').text('Toplantı tarihi ve saati zorunludur.');
        } else {
            const selectedDate = new Date(date.val());
            const now = new Date();
            
            if (selectedDate < now) {
                isValid = false;
                date.next('.validation-message').text('Toplantı tarihi geçmiş bir tarih olamaz.');
            }
        }
        
        if (isValid) {
            form[0].submit();
        }
    });
}); 