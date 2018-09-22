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
