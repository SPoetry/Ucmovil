<?php

use Illuminate\Support\Facades\Schema;
use Illuminate\Database\Schema\Blueprint;
use Illuminate\Database\Migrations\Migration;

class CreateHorariosAtencionesTable extends Migration
{
    /**
     * Run the migrations.
     *
     * @return void
     */
    public function up()
    {
        Schema::create('horarios_atenciones', function (Blueprint $table) {
            $table->integer('id_rut')->references('id')->on('users');
            $table->string('tipo');
            $table->string('dia');
            $table->integer('modulo');
            $table->primary('id_rut');
        });
    }

    /**
     * Reverse the migrations.
     *
     * @return void
     */
    public function down()
    {
        Schema::dropIfExists('horarios_atenciones');
    }
}
