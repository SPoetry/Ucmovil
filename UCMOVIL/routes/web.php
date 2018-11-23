<?php

Route::get('/', function () {
    return view('welcome');
});

Auth::routes();

Route::get('/home', 'HomeController@index')->name('home');

Route::get('/log', 'LoginController@Login');


Route::get('/alumno', 'AlumnoController@index')->name('c_alumno');
Route::get('/d_escuela', 'DirectorCarreraController@index')->name('c_d_escuela');
Route::get('/profesor', 'ProfesorController@index')->name('c_profesor');
Route::get('/secretaria', 'SecretariaController@index')->name('c_secretaria');
Route::get('/datos_d', 'HomeController@datos_d')->name('d_tipo');
Route::get('/datos_s', 'HomeController@datos_s')->name('s_tipo');
Route::get('/datos_a', 'HomeController@datos_a')->name('a_tipo');
Route::get('/datos_p', 'HomeController@datos_p')->name('p_tipo');
Route::get('/cambioC', 'HomeController@cambioC')->name('cambioC');
Route::get('/cambioA', 'HomeController@cambioA')->name('cambioA');
Route::get('/cambioE', 'HomeController@cambioE')->name('cambioE');



Route::get('/CodigoA', 'AsignaturaController@CodigoA')->name('CodigoA');
Route::get('/RamosA', 'AlumnoController@RamosA')->name('RamosA');
Route::get('/NameA', 'AsignaturaController@NameA')->name('NameA');
Route::get('/ProfesorA', 'AsignaturaController@ProfesorA')->name('ProfesorA');
Route::get('/HorarioA', 'AsignaturaController@HorarioA')->name('HorarioA');


Route::get('/NotasA', 'AsignaturaController@NotasA')->name('NotasA');
Route::get('/HistorialA', 'AsignaturaController@HistorialA')->name('HistorialA');
Route::get('/NotasAsignatura', 'AsignaturaController@NotasAsignatura')->name('NotasAsignatura');


Route::get('/d_escuela/mostrar_asignatura', 'DirectorCarreraController@mostrar_asignatura')->name('mostrar_asignatura');
Route::get('/d_escuela/anadir_asignatura', 'DirectorCarreraController@anadir_asignatura')->name('anadir_asignatura');
Route::get('/d_escuela/modificar_asignatura', 'DirectorCarreraController@modificar_asignatura')->name('modificar_asignatura');
Route::get('/d_escuela/borrar_asignatura', 'DirectorCarreraController@borrar_asignatura')->name('borrar_asignatura');


Route::get('/secretaria/mostrar_noticia','SecretariaController@mostrar_noticia')->name('mostrar_noticia');
Route::get('/secretaria/agregar_noticia','SecretariaController@agregar_noticia')->name('agregar_noticia');
Route::get('/secretaria/editar_noticia','SecretariaController@editar_noticia')->name('editar_noticia');


Route::get('/ramos_impartidos', 'ProfesorController@mostrar_impartidos');
Route::get('/ponderaciones', 'ProfesorController@mostrar_ponderaciones');
Route::get('/ingresoponderaciones', 'ProfesorController@ingresar_ponderaciones');
Route::get('/ListaAlumnos', 'ProfesorController@mostrar_lista');
Route::get('/ObtenerNotas', 'ProfesorController@obtener_notas');
