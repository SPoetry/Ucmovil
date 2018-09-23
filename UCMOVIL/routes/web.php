<?php

Route::get('/', function () {
    return view('welcome');
});

Auth::routes();

Route::get('/home', 'HomeController@index')->name('home');


Route::get('/alumno', 'AlumnoController@index')->name('c_alumno');
Route::get('/d_escuela', 'DirectorCarreraController@index')->name('c_d_escuela');
Route::get('/profesor', 'ProfesorController@index')->name('c_profesor');
Route::get('/secretaria', 'SecretariaController@index')->name('c_secretaria');

Route::get('/d_escuela/mostrar_asignatura', 'DirectorCarreraController@mostrar_asignatura')->name('mostrar_asignatura');
Route::get('/d_escuela/anadir_asignatura', 'DirectorCarreraController@anadir_asignatura')->name('anadir_asignatura');
Route::post('/d_escuela/modificar_asignatura', 'DirectorCarreraController@modificar_asignatura')->name('modificar_asignatura');
Route::post('/d_escuela/borrar_asignatura', 'DirectorCarreraController@borrar_asignatura')->name('borrar_asignatura');
