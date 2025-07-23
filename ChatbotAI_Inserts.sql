-- Insert sample users
INSERT INTO Users (Username, Email, PasswordHash, Role)
VALUES 
('Lilo', 'catherine@example.com', 'hashed_password_111', 'User'),
('Michael', 'michael@example.com', 'hashed_password_222', 'User');

-- Insert sample messages (assuming user IDs are 1 and 2)
INSERT INTO Messages (UserId, MessageText, ResponseText)
VALUES
(1, 'How do you toggle password visibility in React?', 'Use a boolean state (e.g., showPwd) and set the inputs type to text or password based on it.'),
(1, 'What icon library was used for the eye icons?', '@heroicons/react was used to display EyeIcon and EyeSlashIcon.'),
(2, 'How do you style an input using Tailwind?', 'Use classes like px-4 py-2 border rounded focus:outline-none focus:ring.'),
(2, 'How do you position the eye icon inside the input box?', 'Use a relative wrapper and an absolute icon with top and right classes.'),
(2, 'How do you validate form fields in this example?', 'The required attribute is used on both inputs for basic HTML validation.')
