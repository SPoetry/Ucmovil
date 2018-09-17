<?php

use Illuminate\Support\Facades\Schema;
use Illuminate\Database\Schema\Blueprint;
use Illuminate\Database\Migrations\Migration;

class CreatePonderacionesRamosTable extends Migration
{
    /**
     * Run the migrations.
     *
     * @return void
     */
    public function up()
    {
        Schema::create('ponderaciones_ramos', function (Blueprint $table) {
          $table->integer('id_ramoimpartido')->references('id_ramoimpartido')->on('ramos_impartidos');
          $table->integer('N_nota');
          $table->float('P_nota');
          $table->primary('id_ramoimpartido');
        });
    }

    /**
     * Reverse the migrations.
     *
     * @return void
     */
    public function down()
    {
        Schema::dropIfExists('ponderaciones_ramos');
    }
}
