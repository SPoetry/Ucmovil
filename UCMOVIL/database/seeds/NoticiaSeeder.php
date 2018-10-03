<?php

use Illuminate\Database\Seeder;

class NoticiaSeeder extends Seeder
{
    /**
     * Run the database seeds.
     *
     * @return void
     */
    public function run()
    {
	DB::table('noticias')->insert([
        'id_noticia' => '1',
        'texto' => 'Esta noticia 1',
        'estado' => 'Revision',
        'propietario' => 'Profesor X'
      ]);

	DB::table('noticias')->insert([
        'id_noticia' => '4',
        'texto' => 'Esta noticia 4',
        'estado' => 'Revision',
        'propietario' => 'Profesor X'
      ]);

	DB::table('noticias')->insert([
        'id_noticia' => '2',
        'texto' => 'Esta noticia 2',
        'estado' => 'Aprobada',
        'propietario' => 'Profesor Y'
      ]);
	DB::table('noticias')->insert([
        'id_noticia' => '3',
        'texto' => 'Esta noticia 3',
        'estado' => 'Rechazada',
        'propietario' => 'Profesor Z'
      ]);
	DB::table('noticias')->insert([
        'id_noticia' => '5',
        'texto' => 'Esta noticia 5',
        'estado' => 'Aprobada',
        'propietario' => 'Profesor Y'
      ]);
	DB::table('noticias')->insert([
        'id_noticia' => '6',
        'texto' => 'Esta noticia 6',
        'estado' => 'Rechazada',
        'propietario' => 'Profesor Z'
      ]);
	}

}