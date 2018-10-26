<?php

use Illuminate\Database\Seeder;

class RamosImpartidoSeeder extends Seeder
{
    /**
     * Run the database seeds.
     *
     * @return void
     */
    public function run()
    {
    	DB::table('ramos_impartidos')->insert([
        	'id_ramoimpartido' => '1',
        	'id_asignatura' => 'ICI-114',
        	'id_profesor' => '2'
      	]);
        DB::table('ramos_impartidos')->insert([
        	'id_ramoimpartido' => '2',
        	'id_asignatura' => 'ICI-115',
        	'id_profesor' => '2'
      	]);
    }
}
