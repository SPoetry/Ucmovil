<?php

use Illuminate\Database\Seeder;

class PonderacionesRamoSeeder extends Seeder
{
    /**
     * Run the database seeds.
     *
     * @return void
     */
    public function run()
    {
      DB::statement('SET FOREIGN_KEY_CHECKS=0;');
      DB::table('ponderaciones_ramos')->truncate();
      DB::statement('SET FOREIGN_KEY_CHECKS=1;');

      for ($i=1; $i <= 10; $i++) {
        DB::table('ponderaciones_ramos')->insert([
            'id_ramo' => '1',
            'N_nota' => $i,
            'P_nota' => '0.2'
          ]);
        }

      for ($i=1; $i <= 10; $i++) {
        DB::table('ponderaciones_ramos')->insert([
            'id_ramo' => '2',
            'N_nota' => $i,
            'P_nota' => '0.2'
          ]);
        }
    }
}
