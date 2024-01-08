<h2 align="center">Author Controller and Services Integration</h2>

### Introduction
This document outlines the implementation of the Author Controller and its services in the project, focusing on CRUD operations and relationship management between Book, Author, and Genre entities.

### - Author Controller Implementation
- **Add Author:** Endpoint to add a new author.
- **Update Author:** Endpoint to update author details.
- **Delete Author:** Endpoint to delete an author, with checks for existing book associations.
- **List Authors:** Endpoint to list all authors.
- **Get Author Details:** Endpoint to fetch specific author information.

### - Author Information Fields
- **First Name**
- **Last Name**
- **Date of Birth**

### - Entity Relationships
- Set up one-to-one relationships between Book and Author.
- Ensuring a book is associated with only one author.

### - Models and DTOs
- Creation of Author Model and DTOs.
- Ensuring separation of Entity models from API inputs/outputs.

### - AutoMapper Implementation
- Utilizing AutoMapper for efficient model mapping.

### - Fluent Validation
- Implementing validation classes with Fluent Validation for Author services.
- Defining custom rules for data integrity.

### - Error Handling
- The system robustly handles errors, particularly in scenarios like attempting to delete an author with published books.
