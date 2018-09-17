<?php

/*
|--------------------------------------------------------------------------
| Web Routes
|--------------------------------------------------------------------------
|
| Here is where you can register web routes for your application. These
| routes are loaded by the RouteServiceProvider within a group which
| contains the "web" middleware group. Now create something great!
|
*/



Route::get('/pedidos', 'PedidosController@show');
Route::get('/pedido/{id}', 'PedidosController@detail');
Route::get('/inventario', 'InventarioController@show')->name('inventario');
Route::get('/', 'Auth\LoginController@showlogin');
Route::post('/login', 'Auth\LoginController@login')->name('login');
Route::post('/logout', 'Auth\LoginController@logout')->name('logout');
Route::post('/pedidos', 'PedidosController@change');
Route::post('/inventario', 'InventarioController@add');
Route::post('/enviarPedido', 'PedidosController@enviar');
