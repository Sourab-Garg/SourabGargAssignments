document.addEventListener('DOMContentLoaded', () => {
    // Get all delete buttons
    const deleteButtons = document.querySelectorAll('.delete');

    // Get the form and input
    const addMovieForm = document.getElementById('add-movie');
    const addMovieInput = document.querySelector('#add-movie input');
    const movieList = document.querySelector('#movie-list ul');

    // Add click event to all delete buttons
    deleteButtons.forEach(btn => {
        btn.addEventListener('click', (e) => {
            // Remove the parent <li> element when delete is clicked
            e.target.parentElement.remove();
        });
    });
    
    // Add event listener to the form
    addMovieForm.addEventListener('submit', (e) => {
        e.preventDefault(); // Prevent form from reloading the page
        
        // Get the movie name from input
        const movieName = addMovieInput.value.trim();
        
        // Only add if input is not empty
        if (movieName === '') {
            alert('Please enter a movie name');
            return;
        }
        
        // Create new list item
        const newLi = document.createElement('li');
        
        // Create movie name span
        const nameSpan = document.createElement('span');
        nameSpan.className = 'name';
        nameSpan.textContent = movieName;
        
        // Create delete button span
        const deleteSpan = document.createElement('span');
        deleteSpan.className = 'delete';
        deleteSpan.textContent = 'delete';
        
        // Add click event to the new delete button
        deleteSpan.addEventListener('click', (e) => {
            e.target.parentElement.remove();
        });
        
        // Append spans to the list item
        newLi.appendChild(nameSpan);
        newLi.appendChild(deleteSpan);
        
        // Append list item to the movie list
        movieList.appendChild(newLi);
        
        // Clear the input field
        addMovieInput.value = '';
    });
});