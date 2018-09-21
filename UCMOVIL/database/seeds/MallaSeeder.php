<?php

use Illuminate\Database\Seeder;

class MallaSeeder extends Seeder
{
    /**
     * Run the database seeds.
     *
     * @return void
     */
    public function run()
    {
      DB::table('mallas')->insert([
        'id_asignatura' => 'ICI-400',
        'semestre' => '1'
      ]);
    }
}