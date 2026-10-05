# PHP + Apache webszerver, ami kiszolgálja a .php és .html fájlokat.
FROM php:8.3-apache

# A mysqli bővítmény kell a MySQL-hez (az alap image-ben nincs benne).
RUN docker-php-ext-install mysqli
