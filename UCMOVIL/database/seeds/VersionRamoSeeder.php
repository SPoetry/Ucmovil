<?php

use Illuminate\Database\Seeder;

class VersionRamoSeeder extends Seeder
{
    /**
     * Run the database seeds.
     *
     * @return void
     */
    public function run()
    {
    	DB::table('version_ramos')->insert([
        	'id_ramo' => '1',
        	'id_asignatura' => 'ICI-114',
        	'id_profesor' => '2',
          'year' => '2018',
          'semestre' => '1'
      	]);
        DB::table('version_ramos')->insert([
          'id_ramo' => '2',
        	'id_asignatura' => 'ICI-115',
        	'id_profesor' => '2',
          'year' => '2018',
          'semestre' => '2'
      	]);
    }
}
