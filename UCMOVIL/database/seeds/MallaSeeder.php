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
      DB::statement('SET FOREIGN_KEY_CHECKS=0;');
      DB::table('mallas')->truncate();
      DB::statement('SET FOREIGN_KEY_CHECKS=1;');

      DB::table('mallas')->insert([
        'id_asignatura' => 'ICI-114',
        'semestre' => '1'
      ]);
    }
}
